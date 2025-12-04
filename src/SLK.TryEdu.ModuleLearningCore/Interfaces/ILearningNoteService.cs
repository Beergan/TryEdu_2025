using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleLearningCore; 
 
[BasePath("api/Learningnote")]
public interface ILearningNoteService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityLearningNote>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityLearningNote>> GetList();
    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityLearningNote info);
}