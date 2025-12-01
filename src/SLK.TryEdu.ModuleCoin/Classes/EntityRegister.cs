using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base; 
using SLK.TryEdu.ModuleCoinCore;

namespace SLK.TryEdu.ModuleCoin;  

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntityCoinBalance>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityCoinExchangeRate>().HasAlternateKey(k => k.Guid);
        modelBuilder.Entity<EntityCoinTransaction>().HasAlternateKey(k => k.Guid);
    }
    public void Seed(IDbContext db)
    {
        
    }
}