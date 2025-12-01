using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base; 
using SLK.TryEdu.ModulePartnerCore;

namespace SLK.TryEdu.ModulePartner;  

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityPartnerCenter>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityReferralCode>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityCommissionTransaction>().HasAlternateKey(k => k.Guid);

    }
    public void Seed(IDbContext db)
    {
        
    }
}