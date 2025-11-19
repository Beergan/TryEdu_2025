using System.Linq;
using System.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SLK.TryEdu.Base;
using SLK.TryEdu.ModuleManagementCore;

namespace SLK.TryEdu.ModuleManagement;

public class ModuleAspNetRegister : IModuleAspNet
{
    public void BuildModule(IApplicationBuilder app)
    {
        GlobalPermissions.Register(typeof(PERMISSION));
    }

    public void ConfigureServices(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration config)
    {
        services.AddScoped<IManagementAccountService, ManagementAccountService>();
        services.AddScoped<IManagementPermissionService, ManagementPermissionService>();
        services.AddScoped<IAuditLogService, AuditLogService>();
    }
}