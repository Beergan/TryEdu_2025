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
using SLK.TryEdu.ModulePartnerCore;

namespace SLK.TryEdu.ModulePartner; 

public class PartnerCenterService : MyServiceBase, IPartnerCenterService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<PartnerCenterService> _log;
    private readonly string _ternantId;

    public PartnerCenterService(IMyContext ctx, ILogger<PartnerCenterService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
    Task<ResultOf<EntityPartnerCenter>> IPartnerCenterService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<ResultsOf<EntityPartnerCenter>> IPartnerCenterService.GetList()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Save([Body] EntityPartnerCenter info)
    {
        throw new NotImplementedException();
    }
}