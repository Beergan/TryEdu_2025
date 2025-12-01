using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleContentCore; 
 
[BasePath("api/Course")]
public interface ICourseService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityCourse>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityCourse>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityCourse info);
}