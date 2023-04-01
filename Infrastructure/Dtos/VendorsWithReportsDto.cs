using ReportApp.DAL.Entities;

namespace ReportApp.Infrastructure.Dtos
{
    public class VendorsWithReportsDto
    {
        public string FullName { get; set; }
        public IEnumerable<VendorReportDto> VendorReports { get; set; }
    }
}
