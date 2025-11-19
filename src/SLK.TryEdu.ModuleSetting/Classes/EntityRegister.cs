using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Prng;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSettingCore;
using Syncfusion.Blazor.Diagram;

namespace SLK.TryEdu.ModuleSetting;

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityNoTifiCation>().HasAlternateKey(x => x.Guid);
        modelBuilder.Entity<EntityCompany>().HasAlternateKey(x => x.Guid);
        modelBuilder.Entity<EntityOffice>().HasAlternateKey(x => x.Guid);
        modelBuilder.Entity<EntityJob>().HasAlternateKey(x => x.Guid);
        modelBuilder.Entity<EntityNoTifiCation>()
           .Property(e => e.Guid_UserNoTify)
           .HasConversion(
               v => Newtonsoft.Json.JsonConvert.SerializeObject(v),
               v => Newtonsoft.Json.JsonConvert.DeserializeObject<Guid[]>(v)
           )
           .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<Guid[]>(
               (c1, c2) => c1.SequenceEqual(c2),
               c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
               c => c.ToArray()
           ));
    }
    public void Seed(IDbContext db)
    {
        var company = new EntityCompany
        {
            Guid = Guid.NewGuid(),
            CompanyName = "Tên công ty",
            CompanyEmail = "info@gmail.com",
            CompanyLogo = "/assets/",
            CompanyPhone = "0123456789",
            CompanyWebSite = "WebSite công ty",
            CompanyOverview = "Giới thiệu về công ty",
        };

        db.Set<EntityCompany>().Add(company);

        db.Set<EntityOffice>().AddRange(
            new EntityOffice {Guid = Guid.Parse("15f0a586-a32f-457a-9523-7ab9c735ee83"), Name = "Sài Gòn", Address = "123 Phạm Văn Đồng, P. 3, Q. Gò Vấp", Email = "info@gmail.com", Phone = "0123456789", Active = true }
        );

        db.Set<EntityJob>().Add( new EntityJob
        {
            JobName = "Giám đốc"
        });
    }
}