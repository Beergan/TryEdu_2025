using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleContentCore;
using System.Linq;
using System.Security;

namespace SLK.TryEdu.ModuleContent;

public class ModuleAspNetRegister : IModuleAspNet
{
    public void BuildModule(IApplicationBuilder app)
    {
        GlobalPermissions.Register(typeof(PERMISSION));
    }

    public void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
    {
        services.AddScoped<ICourseService, CourseService>();
    }
}