using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using RestEase;
using SLK.TryEdu.Abstract;

namespace SLK.TryEdu.ModuleEmployeeCore;

[BasePath("api/Employee")]
public interface IEmployeeService : IServiceBase
{
    [Get(nameof(Get))]
    Task<ResultOf<EntityEmployee>> Get(Guid guid);

    [Get(nameof(GetList))]
    Task<ResultsOf<EntityEmployee>> GetList();

    [Get(nameof(GetListDocument))]
    Task<ResultsOf<ModelEmployeeDocument>> GetListDocument();

    [Post(nameof(Save))]
    Task<Result> Save([Body] EntityEmployee info);

    [Post(nameof(Save))]
    Task<Result> SaveDocument([Body] ModelEmployeeDocument info);

    [Post(nameof(DownloadDocument))]
    Task<Result> DownloadDocument(string fileName);

    [Post(nameof(DeleteDocument))]
    Task<Result> DeleteDocument(int id);

    [Post(nameof(CheckDocument))]
    Task<bool> CheckDocument();

    [Get(nameof(SetToActiveEmployee))]
    Task<Result> SetToActiveEmployee(int id, Guid guidEmployee);
}