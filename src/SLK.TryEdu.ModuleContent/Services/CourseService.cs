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

using SLK.TryEdu.ModuleContentCore;

namespace SLK.TryEdu.ModuleContent;  

public class CourseService : MyServiceBase, ICourseService
{
    private IWebHostEnvironment hostingEnv;
    private readonly ILogger<CourseService> _log;
    private readonly string _ternantId;

    public CourseService(IMyContext ctx, ILogger<CourseService> logger, IWebHostEnvironment env) : base(ctx)
    {
        hostingEnv = env;
        _log = logger;
        //_ternantId = _ctx.TernantId;
    }
   
    Task<ResultOf<EntityCourse>> ICourseService.Get(Guid guid)
    {
        throw new NotImplementedException();
    }

    Task<ResultsOf<EntityCourse>> ICourseService.GetList()
    {
        throw new NotImplementedException();

    }

    public Task<Result> Save([Body] EntityCourse info)
    {
        throw new NotImplementedException();
    }
}