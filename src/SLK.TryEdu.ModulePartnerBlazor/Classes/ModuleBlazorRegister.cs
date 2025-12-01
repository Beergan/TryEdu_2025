using Microsoft.Extensions.DependencyInjection;
using RestEase.HttpClientFactory;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.ModulePartnerCore;

namespace SLK.TryEdu.ModulePartnerBlazor; 

public class ModuleBlazorRegister : IModuleBlazor
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRestEaseClient<IPartnerCenterService>(AppStatic.BaseAddress);
    }
}