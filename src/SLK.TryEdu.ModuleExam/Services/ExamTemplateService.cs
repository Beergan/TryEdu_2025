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

using SLK.TryEdu.ModuleExamCore; 

namespace SLK.TryEdu.ModuleExam;   

public class ExamTemplateService : MyServiceBase, IExamTemplateService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<ExamTemplateService> _log;
    private readonly string _ternantId;

    public ExamTemplateService(IMyContext ctx, ILogger<ExamTemplateService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
    Task<ResultOf<EntityExamTemplate>> IExamTemplateService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<ResultsOf<EntityExamTemplate>> IExamTemplateService.GetList()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Save([Body] EntityExamTemplate info)
    {
        throw new NotImplementedException();
    }
}