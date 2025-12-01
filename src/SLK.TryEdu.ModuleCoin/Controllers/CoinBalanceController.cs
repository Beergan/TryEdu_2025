using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleCoinCore;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SLK.TryEdu.ModuleCoin.Controllers;  

[Authorize]
[Route("api/CoinBalance/[action]")]
[ApiController]
public class CoinBalanceController : CoinBalanceService, ICoinBalanceService
{
    [Obsolete]
    public CoinBalanceController(IMyContext ctx, ILogger<CoinBalanceService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}