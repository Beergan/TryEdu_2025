using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleUserCore; 

[BasePath("api/User")]
public interface IUserService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityUser>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityUser>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityUser info);
}