using Microsoft.AspNetCore.Mvc;
using SLK.TryEdu.ModuleLearningCore; 
using Microsoft.Extensions.Logging;
using SLK.TryEdu.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System; 

namespace SLK.TryEdu.ModuleLearning.Controllers;   

[Authorize]
[Route("api/LearningNote/[action]")]
[ApiController]
public class LearningNoteController : LearningNoteService, ILearningNoteService
{
    [Obsolete]
    public LearningNoteController(IMyContext ctx, ILogger<LearningNoteService> log, IWebHostEnvironment env) : base(ctx, log, env)
    {
    }
}