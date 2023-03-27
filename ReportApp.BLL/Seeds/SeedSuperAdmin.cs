using Microsoft.AspNetCore.Identity;

namespace ReportApp.BLL.Seeds
{
    public class SeedSuperAdmin
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedSuperAdmin(RoleManager<IdentityRole> roleManager)
        {
            _roleManager= roleManager;
        }

        public async Task InitializeSuperAdminRoleAsync()
        {
            bool roleExists = await _roleManager.RoleExistsAsync("SuperAdmin");

            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
        }
    }
}
