using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleExamCore;  
 
[BasePath("api/examtemplate")] 
public interface IExamTemplateService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityExamTemplate>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityExamTemplate>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityExamTemplate info);
}