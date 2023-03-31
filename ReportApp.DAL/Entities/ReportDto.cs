using static ReportApp.DAL.Entities.Enum.HazardRatingEnum;
using static ReportApp.DAL.Entities.Enum.RiskImpactEnum;
using static ReportApp.DAL.Entities.Enum.RiskProbabilityEnum;

namespace ReportApp.Infrastructure.Dtos
{
    public class ReportDto
    {
        public Guid ReportId { get; set; }

        public string Location { get; set; }

        public string HazardDescription { get; set; }

        public string ResourceAtRisk { get; set; }

        public RiskProbability RiskProbability { get; set; } = RiskProbability.low;

        public RiskImpact RiskImpact { get; set; } = RiskImpact.low;

        public string PreventiveMeasure { get; set; }

        public HazardRating HazardRating { get; set; } = HazardRating.low;

        public string? AdditionalInfo { get; set; }

        public Guid? CustomerId { get; set; }
        public Guid? VendorId { get; set; }

    }

}
