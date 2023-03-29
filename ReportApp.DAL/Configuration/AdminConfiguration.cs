using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(
                new Admin
                {
                    Id = new Guid("e87c3a3f-8e56-49c3-9d48-61833e7a1a13"),
                    FullName = "Israel Chidera",
                    Address= "Ugwuaji, Enugu",
                },
                new Admin
                {
                    Id = new Guid("dbdcefb9-7e1f-4699-aa6b-d1636c601f6b"),
                    FullName = "Lumueus Fadeyi",
                    Address = "Ondo,Delta",
                }
                ,
                new Admin
                {
                    Id = new Guid("b4216dbf-f4c1-4b4a-a418-75f4efbc54f4"),
                    FullName = "Ramsey Icee",
                    Address = "Greenwood, Canada",
                }
           );
        }
    }
}
