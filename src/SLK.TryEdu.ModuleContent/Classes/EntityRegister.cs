using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base; 
using SLK.TryEdu.ModuleContentCore;

namespace SLK.TryEdu.ModuleContent;  

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityCourse>().HasAlternateKey(k => k.Guid);

    }
    public void Seed(IDbContext db)
    {
        
    }
}