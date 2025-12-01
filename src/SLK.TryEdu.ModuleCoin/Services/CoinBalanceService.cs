using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RestEase;
using SLK.TryEdu.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using SLK.TryEdu.Base;
using System.Data;
using Syncfusion.XlsIO;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SLK.TryEdu.ModuleCoinCore;

namespace SLK.TryEdu.ModuleCoin;

public class CoinBalanceService : MyServiceBase, ICoinBalanceService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<CoinBalanceService> _log;
    private readonly string _ternantId;

    public CoinBalanceService(IMyContext ctx, ILogger<CoinBalanceService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
    Task<ResultOf<EntityCoinBalance>> ICoinBalanceService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<ResultsOf<EntityCoinBalance>> ICoinBalanceService.GetList()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Save([Body] EntityCoinBalance info)
    {
        throw new NotImplementedException();
    }
}