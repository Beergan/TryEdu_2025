using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SLK.TryEdu.Db.DbPostgres
{
    public class DbPostgresContext : IdentityDbContext<SA_USER>, IDbContext
    {
        public static Action<ModelBuilder> SetupAction { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public string UserId { get; set; }
        public string IpAddress { get; set; }
        public string AuditName { get; set; }
        public Guid GuidCntr { get; set; }

        public DbPostgresContext(DbContextOptions<DbPostgresContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AuditLog>().HasAlternateKey(x => x.Guid);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                            v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime?, DateTime?>(
                            v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v : v.Value.ToUniversalTime()) : v,
                            v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v));
                    }
                }
            }

            SetupAction?.Invoke(builder);
        }

        public IRepository<T> Repo<T>() where T : class => new BaseRepository<T>(this);

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertAllDateTimesToUtc();
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity is EntityBase &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                var entity = (EntityBase)entry.Entity;
                entity.DateModified = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                    entity.DateCreated = DateTime.UtcNow;
            }

            var auditEntries = OnBeforeSaveChanges();

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var audit in auditEntries.Where(a => a.ActionType == "Add"))
            {
                var entity = ChangeTracker.Entries()
                    .FirstOrDefault(e => e.Metadata.GetTableName() == audit.TableName &&
                                         e.Properties.Any(p => p.Metadata.IsPrimaryKey() && p.CurrentValue != null));

                if (entity == null) continue;

                object idValue = null;

                // Xử lý riêng cho các bảng Identity
                switch (audit.TableName)
                {
                    case "AspNetUserRoles":
                        idValue = entity.Property("UserId").CurrentValue;
                        break;
                    case "AspNetRoles":
                    case "AspNetRoleClaims":
                    case "AspNetUserClaims":
                    case "AspNetUsers":
                        idValue = entity.Property("Id").CurrentValue;
                        break;
                    default:
                        idValue = entity.Property("Id").CurrentValue;
                        break;
                }

                if (idValue != null)
                {
                    var changeValues = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(audit.ChangeValues);
                    changeValues["Id"] = JsonSerializer.SerializeToElement(new { Old = (object)null, New = idValue });
                    audit.ChangeValues = JsonSerializer.Serialize(changeValues);
                }
            }

            if (auditEntries.Count > 0)
            {
                AuditLogs.AddRange(auditEntries);
                await base.SaveChangesAsync(cancellationToken);
            }

            return result;
        }
        private void ConvertAllDateTimesToUtc()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                // Convert known base timestamps
                if (entry.Entity is EntityBase entityBase)
                {
                    if (entityBase.DateCreated.Kind != DateTimeKind.Utc)
                        entityBase.DateCreated = entityBase.DateCreated.ToUniversalTime();

                    if (entityBase.DateModified.Kind != DateTimeKind.Utc)
                        entityBase.DateModified = entityBase.DateModified.ToUniversalTime();
                }

                if (entry.Entity is AuditLog auditLog)
                {
                    if (auditLog.CreatedAt.Kind != DateTimeKind.Utc)
                        auditLog.CreatedAt = auditLog.CreatedAt.ToUniversalTime();
                }

                // Convert any other DateTime/DateTime? properties on the entity
                var properties = entry.Properties
                    .Where(p => p.Metadata.ClrType == typeof(DateTime) || p.Metadata.ClrType == typeof(DateTime?));

                foreach (var prop in properties)
                {
                    if (prop.CurrentValue is DateTime dt)
                    {
                        if (dt.Kind != DateTimeKind.Utc)
                            prop.CurrentValue = dt.ToUniversalTime();
                    }
                    else
                    {
                        var nullableDt = prop.CurrentValue as DateTime?;
                        if (nullableDt.HasValue && nullableDt.Value.Kind != DateTimeKind.Utc)
                        {
                            prop.CurrentValue = nullableDt.Value.ToUniversalTime();
                        }
                    }
                }
            }
        }
        private List<AuditLog> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditLog>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var audit = new AuditLog
                {
                    UserName = UserId,
                    TableName = entry.Metadata.GetTableName(),
                    CreatedAt = DateTime.UtcNow
                };

                var changeValues = new Dictionary<string, object>();

                switch (entry.State)
                {
                    case EntityState.Added:
                        audit.ActionType = "Add";
                        changeValues = entry.Properties.ToDictionary(
                            p => p.Metadata.Name,
                            p => (object)new { Old = (object)null, New = p.CurrentValue }
                        );
                        break;

                    case EntityState.Modified:
                        audit.ActionType = "Update";
                        var dbValues = entry.GetDatabaseValues();
                        changeValues = entry.Properties.ToDictionary(
                            p => p.Metadata.Name,
                            p => (object)new { Old = dbValues?[p.Metadata.Name], New = p.CurrentValue }
                        );
                        break;

                    case EntityState.Deleted:
                        audit.ActionType = "Delete";
                        foreach (var prop in entry.Properties)
                        {
                            changeValues[prop.Metadata.Name] = (object)new { Old = prop.OriginalValue, New = (object)null };
                        }
                        break;
                }

                audit.ChangeValues = changeValues.Any()
                    ? JsonSerializer.Serialize(changeValues)
                    : null;

                auditEntries.Add(audit);
            }

            return auditEntries;
        }
    }
}
