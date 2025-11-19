using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLK.TryEdu.Abstract;
using SLK.TryEdu.Base;
using SLK.TryEdu.Db.DbMssql;
using SLK.TryEdu.Db.DbPostgres;

namespace SLK.TryEdu.Db
{
    public class DbPostgresRegister
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config, Action<ModelBuilder> setup)
        {
            DbPostgresContext.SetupAction = setup;

            services.AddDbContext<DbPostgresContext>((sp, options) =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                options.UseNpgsql(config.GetConnectionString("DbPostgresConnection"));
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);

            services.AddIdentity<SA_USER, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Lockout.AllowedForNewUsers = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DbPostgresContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IDbContext>(provider => provider.GetService(typeof(DbPostgresContext)) as IDbContext);

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DbPostgresContext>();
                /* if (db.Database.EnsureCreated())
                {
                } */
            }
        }

    }
}
