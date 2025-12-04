using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base; 
using SLK.TryEdu.ModuleLearningCore;

namespace SLK.TryEdu.ModuleLearning;   

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityLearningNote>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityEnrollment>().HasAlternateKey(k => k.Guid);
    }
    public void Seed(IDbContext db)
    {
        
    }
}