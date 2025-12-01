using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleCoinCore;

namespace SLK.TryEdu.ModuleUserBlazor;

public class ModuleBlazorRegister : IModuleBlazor
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestEaseClient<ICoinBalanceService>(AppStatic.BaseAddress);
    }
}