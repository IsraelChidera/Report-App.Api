using static ReportApp.DAL.Enum.HazardRatingEnum;
using static ReportApp.DAL.Enum.RiskImpactEnum;
using static ReportApp.DAL.Enum.RiskProbabilityEnum;

namespace ReportApp.DAL.Entities
{
    public class Report
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

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
