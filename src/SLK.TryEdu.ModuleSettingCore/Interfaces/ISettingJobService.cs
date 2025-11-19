using RestEase;
using SLK.TryEdu.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace SLK.TryEdu.ModuleSettingCore;

[BasePath("api/Setting/Job")]
public interface ISettingJobService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityJob>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityJob>> GetList();

    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityJob info);

    [Post(nameof(Delete))]
    Task<Result> Delete(int id);
}