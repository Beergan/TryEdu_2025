using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleExamCore;

namespace SLK.TryEdu.ModuleExamBlazor;  

public class ModuleBlazorRegister : IModuleBlazor
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestEaseClient<IExamTemplateService>(AppStatic.BaseAddress);
    }
}