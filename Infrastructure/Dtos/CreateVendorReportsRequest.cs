using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Infrastructure.Dtos
{
    public class CreateVendorReportsRequest
    {
        public string Location { get; set; }
        public string HazardDescription { get; set; }
        public string ResourceAtRisk { get; set; }
        public string RiskProbability { get; set; }
        public string RiskImpact { get; set; }
        public string PreventiveMeasure { get; set; }
        public string HazardRating { get; set; }
        public string AdditionalInfo { get; set; }
        public Guid VendorId { get; set; }
        public string ReportId { get; set; }
    }
}
