using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleSetting;
using SLK.TryEdu.ModuleSettingCore;

namespace SLK.TryEdu.ModuleSetting.Controllers;

[ApiAuthorize]
[Route("api/setting/[controller]/[action]")]
[ApiController]
public class SettingCompanyController : SettingCompanyService, ISettingCompanyService
{
    public SettingCompanyController(IMyContext ctx, ILogger<SettingCompanyService> log) : base(ctx, log)
    {
    }
}