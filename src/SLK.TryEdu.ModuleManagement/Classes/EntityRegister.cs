using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Prng;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleManagementCore;
using Syncfusion.Blazor.Diagram;

namespace SLK.TryEdu.ModuleManagement;

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {
    }
    public void Seed(IDbContext db)
    {
    }
}