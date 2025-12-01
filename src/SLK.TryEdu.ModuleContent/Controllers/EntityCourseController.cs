using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleContentCore; 
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System;

namespace SLK.TryEdu.ModuleContent.Controllers;   

[Authorize]
[Route("api/PartnerCenter/[action]")]
[ApiController]
public class EntityCourseController : CourseService, ICourseService
{
    [Obsolete]
    public EntityCourseController(IMyContext ctx, ILogger<CourseService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}