using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportApp.DAL.Entities;
using static ReportApp.DAL.Entities.Enum.HazardRatingEnum;
using static ReportApp.DAL.Entities.Enum.RiskImpactEnum;
using static ReportApp.DAL.Entities.Enum.RiskProbabilityEnum;

namespace ReportApp.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = new Guid("02a3d3b1-9b57-4c81-b99e-af54041bda38"),
                    Name = "Emmanuel Ogbodo",
                    Address = "1A, Ohiala, New Market Rd., Enugu",
                    Phone = "09087762534",                    
                },

                new Customer
                {
                    Id = new Guid("ab873ce9-f1f1-45c2-a925-bf24e0c3a3a7"),
                    Name = "Chioma Chukwuka",
                    Phone = "08115627788",                    
                },

                new Customer
                {
                    Id = new Guid("8a8c1f05-3255-4f9d-80d8-00c2d17221bf"),
                    Name = "Emeka Anslem",
                    Phone = "09112783833",
                    Address = "5A, Riverdale street, L.A"
                }

            );
        }
    }
}
