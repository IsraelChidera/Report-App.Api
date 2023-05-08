using ReportApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReportApp.DAL.Enum.HazardRatingEnum;
using static ReportApp.DAL.Enum.RiskImpactEnum;
using static ReportApp.DAL.Enum.RiskProbabilityEnum;

namespace ReportApp.BLL.Dtos.Request
{
    public class ReportRequestDto
    {       
        [Required(ErrorMessage = "Location is a required field")]
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
        
    }
}
