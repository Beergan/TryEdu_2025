using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleEmployeeCore;

namespace SLK.TryEdu.ModuleEmployeeBlazor;

public class ModuleBlazorRegister : IModuleBlazor
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestEaseClient<IEmployeeService>(AppStatic.BaseAddress);
    }
}