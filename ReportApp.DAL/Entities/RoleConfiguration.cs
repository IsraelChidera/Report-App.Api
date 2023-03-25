using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReportApp.DAL.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
               new IdentityRole
               {
                   Name = "Vendor",
                   NormalizedName = "VENDOR",
               },

               new IdentityRole
               {
                   Name = "Seller",
                   NormalizedName = "SELLER",
               },

               new IdentityRole
               {
                   Name = "Admin",
                   NormalizedName = "ADMIN",
               });
        }
    }
}