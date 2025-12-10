using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.Circuits;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MudBlazor.Services;
using Newtonsoft.Json;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.Db;
using SLK.TryEdu.WebApp;
using SLK.TryEdu.WebHost;
using SLK.TryEdu.WebHost.Classes;
using SLK.TryEdu.WebHost.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using Syncfusion.Blazor;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configs = builder.Configuration;

if (!builder.Environment.IsDevelopment())
{
    //builder.WebHost.UseSentry(options =>
    //{
    //    options.StackTraceMode = StackTraceMode.Enhanced;
    //    options.ServerName = configs.GetValue<string>("Sentry:ServerName");
    //    options.Release = AutoClass.FullVersion + " " + AutoClass.BuildName;
    //});
}
var dbType = configs.GetValue<string>("AppSettings:DbType");
switch (dbType)
{
    case "Mssql":
        DbMssqlRegister.ConfigureServices(services, configs, (builder) =>
        {
            var entities = AssembliesUtil.GetAspNetAssemblies().GetInstances<IEntityRegister>();
            foreach (var i in entities)
            {
                i.RegisterEntities(builder);
            }
        });
        break;

    case "Mysql":
        DbMysqlRegister.ConfigureServices(services, configs, (builder) =>
        {
            var entities = AssembliesUtil.GetAspNetAssemblies().GetInstances<IEntityRegister>();
            foreach (var i in entities)
            {
                i.RegisterEntities(builder);
            }
        });
        break;

    case "Postgres":
        DbPostgresRegister.ConfigureServices(services, configs, (builder) =>
        {
            var entities = AssembliesUtil.GetAspNetAssemblies().GetInstances<IEntityRegister>();
            foreach (var i in entities)
            {
                i.RegisterEntities(builder);
            }
        });
        break;
    case "Memory":
        DbMemoryRegister.ConfigureServices(services, configs, (builder) =>
        {
            var entities = AssembliesUtil.GetAspNetAssemblies().GetInstances<IEntityRegister>();
            foreach (var i in entities)
            {
                i.RegisterEntities(builder);
            }
        });
        break;
}

services.AddScoped<Func<IDbContext>>((provider) => () => provider.GetRequiredService<IDbContext>());
services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
services.AddScoped(typeof(ICacheRepository<>), typeof(CacheRepository<>));
services.AddScoped<IMyContext, MyContext>();
services.AddScoped<IOtpService,OtpService>();
services.AddDatabaseDeveloperPageExceptionFilter();


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;            
//    options.DefaultSignInScheme = "AdminCookies";
//})
//.AddCookie("UserCookies", options =>
//{
//    options.LoginPath = "/login";
//    options.LogoutPath = "/logout";
//    options.AccessDeniedPath = "/student/access-denied";
//    options.ExpireTimeSpan = TimeSpan.FromDays(30);
//    options.SlidingExpiration = true;
//    options.Cookie.Name = "UserAuth";
//})
//.AddCookie("AdminCookies", options =>
//{
//    options.LoginPath = "/admin/login";
//    options.LogoutPath = "/admin/logout";
//    options.AccessDeniedPath = "/admin/access-denied";
//    options.ExpireTimeSpan = TimeSpan.FromDays(1);
//    options.SlidingExpiration = true;
//    options.Cookie.Name = "AdminAuth";
//})
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = builder.Configuration["JwtToken:Audience"],
//        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
//        ClockSkew = TimeSpan.Zero,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SigningKey"]))
//    };
//    options.Events = new JwtBearerEvents
//    {
//        OnMessageReceived = context =>
//        {
//            if (context.Request.Cookies.ContainsKey("Auth"))
//            {
//                string token = context.Request.Cookies["Auth"];
//                if (!string.IsNullOrEmpty(token))
//                {
//                    context.Token = token;
//                }
//            }
//            return Task.CompletedTask;
//        },
//        OnChallenge = async (context) =>
//        {
//            context.HandleResponse();

//            var user = context.HttpContext.User;
//            if (!user.Identity.IsAuthenticated)
//            {
//                if (context.HttpContext.Request.Path.Value.StartsWith("/api"))
//                {
//                    context.Response.StatusCode = 200;
//                    context.Response.ContentType = "application/json";
//                    await context.HttpContext.Response.WriteAsync("{\"success\":false,\"message\":\"Xác thực thất bại!\"}");
//                }
//                else
//                {
//                    context.Response.Redirect("/admin/login");
//                }
//            }
//        }
//    };
//});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtToken:Audience"],
        ValidIssuer = builder.Configuration["JwtToken:Issuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtToken:SigningKey"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            if (context.Request.Cookies.ContainsKey("Auth"))
            {
                string token = context.Request.Cookies["Auth"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Token = token;
                }
            }
            return Task.CompletedTask;
        },
        OnChallenge = async (context) =>
        {
            context.HandleResponse();

            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                if (context.HttpContext.Request.Path.Value.StartsWith("/api"))
                {
                    context.Response.StatusCode = 200;
                    context.Response.ContentType = "application/json";
                    await context.HttpContext.Response.WriteAsync("{\"success\":false,\"message\":\"Xác thực thất bại!\"}");
                }
                else
                {
                    context.Response.Redirect("/login");
                }
            }
        }
    };
});
services.AddHttpContextAccessor();
builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddRazorPages(options =>
{
    options.AddTryEduRoutes(enableCustomConstraints: true, enableSeo: true);
})
.AddDataAnnotationsLocalization(o =>
{
    o.DataAnnotationLocalizerProvider = (t, f) => new MyStringLocalizer(services);
});
builder.Services.AddServerSideBlazor()
    .AddCircuitOptions(o => o.DetailedErrors = true); // thêm ở đây
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR();

services.AddScoped<ISessionId, SessionId>();
services.AddScoped<IAuthService, ServerAuthService>();
//services.AddScoped<HostAuthenticationStateProvider>();
//services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<HostAuthenticationStateProvider>());
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

services.AddMudServices();
services.AddSyncfusionBlazor();
services.AddScoped<LazyAssemblyLoader>();
services.AddScoped<ISweetAlertService, SweetAlertServerService>();
services.AddScoped<IMyCookie, MyCookieServer>();
services.AddSingleton(typeof(FieldExtractor<>));

//services.AddScoped<ICultureService>(sp => new CultureService(Assembly.GetExecutingAssembly()));
services.AddScoped<ITextTranslator, TextTranslatorForServer>();
services.AddScoped<INotifyService, NotifyService>();
//services.AddScoped<ISyncfusionStringLocalizer, TextTranslatorForServer>();
services.AddScoped<IBlazorContext, MyContext>();
services.AddScoped<IServiceBase, MyServiceBase>();
services.AddScoped<IMailSettingService, MailSettingService>();
services.AddScoped<CircuitHandler, CircuitHandlerService>();

//services.AddScoped<IMediatorHangfireBridge, MediatorHangfireBridge>();
services.AddHangfire((sp, config) =>
{
    config.UseMemoryStorage();
    config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
});
services.AddHangfireServer();

services.Configure<CacheConfiguration>(configs.GetSection("CacheConfiguration"));
services.AddMemoryCache();

services.AddTransient<MemoryCacheService>();
//services.AddTransient<RedisCacheService>();

services.AddTransient<Func<CacheMode, ICacheService>>(serviceProvider => key =>
{
    switch (key)
    {
        case CacheMode.Memory:
            return serviceProvider.GetRequiredService<MemoryCacheService>();
        //case CacheTech.Redis:
        //    return serviceProvider.GetService<RedisCacheService>();
        default:
            return serviceProvider.GetRequiredService<MemoryCacheService>();
    }
});

var assemblies = AssembliesUtil.GetAspNetAssemblies();
var aspnetModules = assemblies.GetInstances<IModuleAspNet>();
foreach (var module in aspnetModules)
{
    module.ConfigureServices(services, configs);
}
services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
services.Configure<MailSettings>(configs.GetSection("MailSettings"));
services.AddScoped<IEmailRenderer, RazorEmailRenderer>();

string SwaggerEnabled = configs.GetValue<string>("SwaggerEnabled", "");

if (SwaggerEnabled.ToLower() == "true")
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Cntr Workshop",
            Description = "Hệ thống quản lý bảo dưỡng container",
        });

        options.AddJsonQuerySupport();

        options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
        });

        var aspnetssemblies = AssembliesUtil.GetAspNetAssemblies();
        foreach (var module in aspnetssemblies)
        {
            options.IncludeXmlComments(module.Location.Replace(".dll", "Core.xml"), includeControllerXmlComments: true);
            options.IncludeXmlComments(module.Location.Replace(".dll", ".xml"), includeControllerXmlComments: true);
        }

        var xmlHostPath = Path.Combine(System.AppContext.BaseDirectory, "SLK.TryEdu.WebHost.xml");
        options.IncludeXmlComments(xmlHostPath, includeControllerXmlComments: true);
    });
}

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseBlazorFrameworkFiles();
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/switch-to-wasm", (HttpContext ctx) =>
{
    ctx.Response.Cookies.Delete("blazorMode");
    ctx.Response.Cookies.Append("blazorMode", "wasm", new CookieOptions { Expires = DateTime.UtcNow.AddDays(30) });
    ctx.Response.Redirect(ctx.Request.Query["redirect"]!);
});

app.MapGet("/switch-to-server", (HttpContext ctx) =>
{
    ctx.Response.Cookies.Delete("blazorMode");
    ctx.Response.Cookies.Append("blazorMode", "server", new CookieOptions { Expires = DateTime.UtcNow.AddDays(30) });
    ctx.Response.Redirect(ctx.Request.Query["redirect"]!);
});

if (SwaggerEnabled.ToLower() == "true")
{

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
        options.DocExpansion(DocExpansion.None);
        options.ConfigObject.AdditionalItems.Add("tagsSorter", "alpha");
    });
}
System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("vi-VN");
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

//app.MapBlazorHub(options =>
//{
//    options.WebSockets.CloseTimeout = new TimeSpan(1, 1, 1);
//    options.LongPolling.PollTimeout = new TimeSpan(1, 0, 0);
//});

app.MapBlazorHub();
app.MapRazorPages();
app.MapControllers();

SyncfusionLicense.Register();

foreach (var module in aspnetModules)
{
    module.BuildModule(app);
}
//await app.Services.CreateOrUpdateTernant("localhost");


app.Services.MakeMeCanResolveFromStatic();

app.UseCors();


app.Run();