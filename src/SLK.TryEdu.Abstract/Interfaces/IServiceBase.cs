using RestEase;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SLK.TryEdu.Abstract;

public interface IServiceBase
{
    [Get(nameof(GetListPermissions))]
    Task<List<KeyValuePair<FeatureModel, Tuple<long, string, string>[]>>> GetListPermissions();

    [Get(nameof(GetOptionCompany))]
    Task<OptionItem<Guid>> GetOptionCompany();

    [Get(nameof(GetOptionOffices))]
    Task<List<OptionItem<Guid>>> GetOptionOffices();
    [Get(nameof(GetlistCustomer))]
    Task<List<ModelListCustomer>> GetlistCustomer();
    [Get(nameof(GetOptionJob))]
    Task<List<OptionItem<Guid>>> GetOptionJob();

    [Get(nameof(GetInfoEmployee))]
    Task<ModelInfoEmployee> GetInfoEmployee(Guid guid);

    [Get(nameof(GetListService))]
    Task<List<ModelService>> GetListService();

    [Get(nameof(GetInforCustomer))]
    Task<ModelListCustomer> GetInforCustomer(Guid guid);
}