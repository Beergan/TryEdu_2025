using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModuleLearningCore;

namespace SLK.TryEdu.ModuleContentBlazor;  

public class ModuleBlazorRegister : IModuleBlazor
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestEaseClient<ILearningNoteService>(AppStatic.BaseAddress);
    }
}