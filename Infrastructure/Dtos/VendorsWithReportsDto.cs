using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.Infrastructure.Dtos
{
    public class VendorsWithReportsDto
    {
        public string FullName { get; set; }
        public IEnumerable<ReportDto> VendorReports { get; set; }
    }
}
