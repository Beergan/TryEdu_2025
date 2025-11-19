using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleEmployeeCore;
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SLK.TryEdu.ModuleEmployee.Controllers;

[Authorize]
[Route("api/Employee/[action]")]
[ApiController]
public class EmployeeController : EmployeeService, IEmployeeService
{
    [Obsolete]
    public EmployeeController(IMyContext ctx, ILogger<EmployeeService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}