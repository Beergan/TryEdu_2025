using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleExamCore; 
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System; 

namespace SLK.TryEdu.ModuleExam.Controllers;   

[Authorize]
[Route("api/ExamTemplate/[action]")]
[ApiController]
public class ExamTemplateServiceController : ExamTemplateService, IExamTemplateService
{
    [Obsolete]
    public ExamTemplateServiceController(IMyContext ctx, ILogger<ExamTemplateService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}