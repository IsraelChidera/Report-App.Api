using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportApp.DAL.Entities;
using static ReportApp.DAL.Entities.Enum.HazardRatingEnum;
using static ReportApp.DAL.Entities.Enum.RiskImpactEnum;
using static ReportApp.DAL.Entities.Enum.RiskProbabilityEnum;

namespace ReportApp.DAL.Configuration
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {

            builder.HasData(
                new Vendor
                {
                    Id = new Guid("ee3d9db9-0a70-4c81-a1a1-2c152b2d0ca7"),
                    Name = "Darlington Obinna",
                    Address = "Genesis estate, Alagbado, Lagos",
                    Phone = "0906234566"
                },

                new Vendor
                {
                    Id = new Guid("a58b932a-562f-4c4a-8724-4c7dfc4b8d12"),
                    Name = "Joy Lobo",
                    Address = "Captain bus stop, Agbele, Lagos",
                    Phone = "0906234566"                    
                },

                 new Vendor
                 {
                     Id = new Guid("c580a7b9-1431-4df1-ba4b-347e4c4fbba8"),
                     Name = "Glory Chinonye",
                     Address = "Akara junction, Nsukka",
                     Phone = "08146255234"
                 }

            );
        }
    }
}
