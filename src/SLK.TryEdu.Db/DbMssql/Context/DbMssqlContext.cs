using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using Syncfusion.Blazor.Diagrams;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SLK.TryEdu.Db.DbMssql;

public class DbMssqlContext : IdentityDbContext<SA_USER>, IDbContext
{
    public static Action<ModelBuilder> SetupAction { get; set; }

    public DbSet<AuditLog> AuditLogs { get; set; }
    public string UserId { get; set; }

    public string IpAddress { get; set; }

    public string AuditName { get; set; }

    public Guid GuidCntr { get; set; }

    public DbMssqlContext(DbContextOptions<DbMssqlContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AuditLog>().HasAlternateKey(x => x.Guid);

        SetupAction?.Invoke(builder);


        //builder.SeedData();
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(string.Format("Server=(localdb)\\mssqllocaldb;Database=Tenant_{0};Trusted_Connection=True;MultipleActiveResultSets=true", _tenant.Host));
    //}

    public IRepository<T> Repo<T>() where T: class
    {
        return new BaseRepository<T>(this);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var auditEntries = OnBeforeSaveChanges();

        var result = await base.SaveChangesAsync(cancellationToken);

        foreach (var audit in auditEntries.Where(a => a.ActionType == "Add"))
        {
            var entity = ChangeTracker.Entries()
                .FirstOrDefault(e => e.Metadata.GetTableName() == audit.TableName &&
                                     e.Properties.Any(p => p.Metadata.IsPrimaryKey() && p.CurrentValue != null));

            if (entity != null)
            {
                switch (audit.TableName)
                {
                    case "AspNetRoles":
                    case "AspNetRoleClaims":
                    case "AspNetUserClaims":
                    case "AspNetUsers":
                        object idValue_Roles = entity.Property("Id").CurrentValue;
                        var changeValuesDict_Roles = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(audit.ChangeValues);
                        changeValuesDict_Roles["Id"] = JsonSerializer.SerializeToElement(new { Old = (object)null, New = idValue_Roles });
                        audit.ChangeValues = JsonSerializer.Serialize(changeValuesDict_Roles);
                        //audit.RecordId = Convert.ToInt32(idValue_Roles);
                        break;
                    case "AspNetUserRoles":
                        object userIdValue_Roles = entity.Property("UserId").CurrentValue;
                        var changeValuesDict_userIdRoles = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(audit.ChangeValues);
                        changeValuesDict_userIdRoles["UserId"] = JsonSerializer.SerializeToElement(new { Old = (object)null, New = userIdValue_Roles });
                        audit.ChangeValues = JsonSerializer.Serialize(changeValuesDict_userIdRoles);
                        //audit.RecordId = Convert.ToInt32(idValue_Roles);
                        break;
                    default:
                        object idValue_Def = entity.Property("Id").CurrentValue;
                        //object guidValue_Def = entity.Property("Guid").CurrentValue;
                        var changeValuesDict_Def = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(audit.ChangeValues);
                        changeValuesDict_Def["Id"] = JsonSerializer.SerializeToElement(new { Old = (object)null, New = idValue_Def });
                        //audit.RecordGuid = (Guid)guidValue_Def;
                        //audit.RecordId = (int)idValue_Def;
                        audit.ChangeValues = JsonSerializer.Serialize(changeValuesDict_Def);
                        break;
                }




                //object idValue = entity.Property("Id").CurrentValue;
                //object guidValue = entity.Property("Guid").CurrentValue;
                //var changeValuesDict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(audit.ChangeValues);
                //changeValuesDict["Id"] = JsonSerializer.SerializeToElement(new { Old = (object)null, New = idValue });
                //audit.RecordGuid = (Guid)guidValue;
                //audit.ChangeValues = JsonSerializer.Serialize(changeValuesDict);
            }
        }

        if (auditEntries.Count > 0)
        {
            AuditLogs.AddRange(auditEntries);
            await base.SaveChangesAsync(cancellationToken);
        }

        return result;
    }


    private List<AuditLog> OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var auditEntries = new List<AuditLog>();

        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                continue;

            AuditLog audit = new AuditLog();
            audit.UserName = UserId;
            audit.TableName = entry.Metadata.GetTableName();

            Dictionary<string, object> changeValues = new();

            switch (entry.State)
            {
                case EntityState.Added:
                    audit.ActionType = "Add";
                    changeValues = entry.Properties.ToDictionary(p => p.Metadata.Name, p => (object)new { Old = (object)null, New = p.CurrentValue });
                    break;

                case EntityState.Modified:
                    audit.ActionType = "Update";
                    // Lấy full
                    var dbValues = entry.GetDatabaseValues();
                    changeValues = entry.Properties.ToDictionary(p => p.Metadata.Name, p => (object)new { Old = dbValues?[p.Metadata.Name], New = p.CurrentValue });

                    //So sánh lấy field nào thay đổi
                    //var dbValues = entry.GetDatabaseValues();

                    //foreach (var prop in entry.Properties)
                    //{
                    //    var oldValue = dbValues?[prop.Metadata.Name];
                    //    var newValue = prop.CurrentValue;

                    //    if (!Equals(oldValue, newValue))
                    //    {
                    //        changeValues[prop.Metadata.Name] = new { Old = oldValue, New = newValue };
                    //    }
                    //}
                    break;

                case EntityState.Deleted:
                    audit.ActionType = "Delete";
                    foreach (var prop in entry.Properties)
                    {
                        changeValues[prop.Metadata.Name] = new { Old = prop.OriginalValue, New = (object)null };
                    }
                    break;
            }

            if (changeValues.Any())
            {
                audit.ChangeValues = JsonSerializer.Serialize(changeValues);
                auditEntries.Add(audit);
            }
            else
            {
                audit.ChangeValues = null;
            }
        }

        return auditEntries;
    }

}