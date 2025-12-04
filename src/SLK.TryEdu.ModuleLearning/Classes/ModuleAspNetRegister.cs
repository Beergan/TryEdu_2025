using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleLearningCore;
using System.Linq;
using System.Security;

namespace SLK.TryEdu.ModuleLearning; 

public class ModuleAspNetRegister : IModuleAspNet
{
    public void BuildModule(IApplicationBuilder app)
    {
        GlobalPermissions.Register(typeof(PERMISSION));
    }

    public void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
    {
        services.AddScoped<ILearningNoteService, LearningNoteService>();
    }
}