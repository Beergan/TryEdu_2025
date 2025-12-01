using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModulePartnerCore;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SLK.TryEdu.ModulePartner.Controllers;   

[Authorize]
[Route("api/PartnerCenter/[action]")]
[ApiController]
public class PartnerCenterController : PartnerCenterService, IPartnerCenterService
{
    [Obsolete]
    public PartnerCenterController(IMyContext ctx, ILogger<PartnerCenterService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}