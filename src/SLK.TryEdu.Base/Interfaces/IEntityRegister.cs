using Microsoft.EntityFrameworkCore;

namespace SLK.TryEdu.Base;

public interface IEntityRegister
{
    void RegisterEntities(ModelBuilder modelbuilder);

    void Seed(IDbContext db);
}