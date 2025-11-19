using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

[BasePath("api/notifier")]
public interface INotifyService
{
    [Post(nameof(AddNotify))]
    Task<Result> AddNotify(string content, string href);

    [Get(nameof(GetNotifies))]
    Task<ResultsOf<ModelNotification>> GetNotifies();
}