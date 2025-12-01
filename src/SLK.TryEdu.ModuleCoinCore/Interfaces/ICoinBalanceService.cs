using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleCoinCore ; 

[BasePath("api/CoinBalance")]
public interface ICoinBalanceService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityCoinBalance>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityCoinBalance>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityCoinBalance info);
}