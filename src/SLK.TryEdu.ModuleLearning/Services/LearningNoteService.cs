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

using SLK.TryEdu.ModuleLearningCore; 

namespace SLK.TryEdu.ModuleLearning;  

public class LearningNoteService : MyServiceBase, ILearningNoteService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<LearningNoteService> _log;
    private readonly string _ternantId;

    public LearningNoteService(IMyContext ctx, ILogger<LearningNoteService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
    Task<ResultOf<EntityLearningNote>> ILearningNoteService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<ResultsOf<EntityLearningNote>> ILearningNoteService.GetList()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Save([Body] EntityLearningNote info)
    {
        throw new NotImplementedException();
    }
}