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

        public DbSet<Report> Reports { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ReportConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }



    }
}
