using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;
using ReportApp.BLL.Services;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL;
using System.Reflection;
using AutoMapper;

namespace Report_App.Api
{
    public static class ServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUsers, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ReportDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReportDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConn")
            ));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            //services.a
            //services.AddAutoMapper(typeof(MappingProfile));
            //services.AddAutoMapper(Assembly.Load("Report_App.Api"));
        }

    }
}
