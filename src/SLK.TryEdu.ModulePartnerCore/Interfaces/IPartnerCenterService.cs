using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModulePartnerCore ; 

[BasePath("api/PartnerCenter")]
public interface IPartnerCenterService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityPartnerCenter>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityPartnerCenter>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityPartnerCenter info);
}