using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;
using ReportApp.DAL.Configuration;
using ReportApp.DAL.Entities;

namespace ReportApp.DAL
{
    public class ReportDbContext : IdentityDbContext<AppUsers>
    {
        public ReportDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Vendor> vendors { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Admin> admins { get; set; }

    }
}
