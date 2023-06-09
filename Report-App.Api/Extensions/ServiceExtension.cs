﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReportApp.BLL.Entities;
using ReportApp.BLL.Services;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL;
using ReportApp.DAL.Repository;
using System.Text;

namespace Report_App.Api.Extensions
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
                opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConn")));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<ReportDbContext>>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {

        });


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration config)
        {
            //save your secret keys in an environment variable rather than in code
            //using the statememnt below.
            //open the cmd window as an administrator
            //This is going to create a system environment variable
            //setx REPORTAPISECRET "ReportAPISecretKey" /M
            var jwtSettings = config.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("REPORTAPISECRET") ?? "Fk24632Pz3gyJLYeYqJ6D8qELyNPUubr8vstypCgfMAC8Jyb3B";

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["validIssuer"],
                        ValidAudience = jwtSettings["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


        }

    }
}
