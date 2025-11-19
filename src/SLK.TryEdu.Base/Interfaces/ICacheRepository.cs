using System.Collections.Generic;
using System.Threading.Tasks;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.Base;

public interface ICacheRepository<T> : IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetListWithCache();

    Task<T> InsertWithCache(T entity);

    Task UpdateWithCache(T entity);
    
    Task RemoveWithCache(T entity);

    Task RefreshCache();
}