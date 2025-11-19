using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SLK.TryEdu.Base;

public interface IModuleAspNet
{
    void ConfigureServices(IServiceCollection services, IConfiguration config);

    void BuildModule(IApplicationBuilder app);
}