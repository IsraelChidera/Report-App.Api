﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReportApp.DAL.Entities;
using static ReportApp.DAL.Enum.HazardRatingEnum;
using static ReportApp.DAL.Enum.RiskImpactEnum;
using static ReportApp.DAL.Enum.RiskProbabilityEnum;

namespace ReportApp.DAL.Configuration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasData(
                new Report()
                {
                    ReportId = new Guid("d4d1554e-4a96-4a34-bc71-c1f9b3ceba06"),
                    Location = "Ikeja, Lagos",
                    HazardDescription = "Environment is ...",
                    ResourceAtRisk = "Environment",
                    RiskProbability = RiskProbability.middle,
                    RiskImpact = RiskImpact.middle,
                    PreventiveMeasure = "To ... ...",
                    HazardRating = HazardRating.low,
                    AdditionalInfo = "Jo ..",                    
                },

                new Report()
                {
                    ReportId = new Guid("8c90bb06-13e5-4d8f-a14f-5461b9d2703a"),
                    Location = "Enugu, Enugu",
                    HazardDescription = "Environment is ...",
                    ResourceAtRisk = "Environment",
                    RiskProbability = RiskProbability.middle,
                    RiskImpact = RiskImpact.middle,
                    PreventiveMeasure = "Eradixcated the use of pumps",
                    HazardRating = HazardRating.low,
                    AdditionalInfo = "Jo ..",
                    
                },

                new Report()
                {
                    ReportId = new Guid("a99b6593-2497-4baf-8568-15aa1c2f2e22"),
                    Location = "Enugu, Enugu",
                    HazardDescription = "Environment is ...",
                    ResourceAtRisk = "Environment",
                    RiskProbability = RiskProbability.middle,
                    RiskImpact = RiskImpact.middle,
                    PreventiveMeasure = "Eradixcated the use of pumps",
                    HazardRating = HazardRating.low,
                    AdditionalInfo = "Jo ..",
                   
                },
                new Report()
                {
                    ReportId = new Guid("5f5ca5c5-3b5e-40a3-9a9e-9fa9b7d04d51"),
                    Location = "Agbelekale, Laos",
                    HazardDescription = "Fashion world is ...",
                    ResourceAtRisk = "Environment",
                    RiskProbability = RiskProbability.middle,
                    RiskImpact = RiskImpact.middle,
                    PreventiveMeasure = "Remains of clothes ...",
                    HazardRating = HazardRating.low,
                    AdditionalInfo = "Jo ..",
                    
                },

                new Report()
                {
                    ReportId = new Guid("10bc62a1-e8a6-476f-8fc2-743c1f46b8d8"),
                    Location = "Nsukka, Enugu",
                    HazardDescription = "Baking is ...",
                    ResourceAtRisk = "Environment",
                    RiskProbability = RiskProbability.middle,
                    RiskImpact = RiskImpact.middle,
                    PreventiveMeasure = "Cakes and cakes materials ...",
                    HazardRating = HazardRating.low,
                    AdditionalInfo = "Jo .."
                }

            );
        }
    }
}
