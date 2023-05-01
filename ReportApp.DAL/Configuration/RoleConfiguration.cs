using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReportApp.DAL.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Name = "Employee",
                   NormalizedName = "EMPLOYEE",
               },

               new IdentityRole
               {
                   Name = "Organization",
                   NormalizedName = "ORGANIZATION",
               },

               new IdentityRole
               {
                   Name = "Admin",
                   NormalizedName = "ADMIN",
               });
        }
    
    }
}