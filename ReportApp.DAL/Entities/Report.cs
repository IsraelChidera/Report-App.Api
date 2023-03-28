using ReportApp.DAL.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ReportApp.DAL.Entities.Enum.HazardRatingEnum;
using static ReportApp.DAL.Entities.Enum.RiskImpactEnum;
using static ReportApp.DAL.Entities.Enum.RiskProbabilityEnum;

namespace ReportApp.DAL.Entities
{
    public class Report 
    {
        [Column("ReportId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Location is a required field")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Hazard Description is a required field")]
        public string HazardDescription { get; set; }

        [Required(ErrorMessage = "Resource at risk is a required field")]
        public string ResourceAtRisk { get; set; }

        public RiskProbability RiskProbability { get; set; } = RiskProbability.low;

        public RiskImpact RiskImpact { get; set; } = RiskImpact.low;

        [Required(ErrorMessage = "Preventive measure is a required field")]
        public string PreventiveMeasure { get; set; }
        
        public HazardRating HazardRating { get; set; } = HazardRating.low;

        public string? AdditionalInfo { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(Vendor))]
        public Guid VendorId { get; set; }

        [ForeignKey(nameof(Admin))]
        public Guid AdminId { get; set; }

        public Customer? Customer { get; set; }

        public Vendor? Vendor { get; set; }
         
    }
}
