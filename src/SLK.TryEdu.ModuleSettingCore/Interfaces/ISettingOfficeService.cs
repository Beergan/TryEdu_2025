using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using System;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleSettingCore;

[BasePath("api/Setting/Office")]
public interface ISettingOfficeService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityOffice>> Get();

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityOffice>> GetList();

    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityOffice info);

    [Post(nameof(Delete))]
    Task<Result> Delete(int id);

    [Get(nameof(SetToPrimary))]
    Task<Result> SetToPrimary(int id);

    [Get(nameof(SetToActive))]
    Task<Result> SetToActive(int id);
}