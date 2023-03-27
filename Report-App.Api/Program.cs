using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Report_App.Api.Extensions;
using ReportApp.BLL.Entities;

namespace Report_App.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureServices();
            builder.Services.AddAutoMapper(Assembly.Load("ReportApp.BLL"));
            builder.Services.ConfigureJWT(builder.Configuration);
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            // Create the SuperAdmin role and user
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUsers>>();

            // Create the SuperAdmin role
            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            //grants super admin access to all routes
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminPolicy", policy =>
                    policy.RequireRole("SuperAdmin"));
            });

            // Create the SuperAdmin user with the role
            var superAdmin = new AppUsers
            {
                UserName = "superadmin@example.com",
                Email = "superadmin@example.com"               
            };
            var result = await userManager.CreateAsync(superAdmin, "SuperAdminPassword1!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");

                await app.RunAsync();
            }

        }
    }
}