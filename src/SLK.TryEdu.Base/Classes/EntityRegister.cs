using Microsoft.EntityFrameworkCore;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public class EntityRegister : IEntityRegister
{
    public void RegisterEntities(ModelBuilder modelBuilder)
    {

    }

    public void Seed(IDbContext db)
    {
    }
}