using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;
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

    }
}
