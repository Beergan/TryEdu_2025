using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleSettingCore;

[BasePath("api/Setting/Company")]
public interface ISettingCompanyService
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityCompany>> Get();

    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityCompany info);

    [Post(nameof(CheckPermission))]
    bool CheckPermission();
}