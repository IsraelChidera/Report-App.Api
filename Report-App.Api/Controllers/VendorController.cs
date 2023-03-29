using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;

namespace Report_App.Api.Controllers
{
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IReportService _reportService;
        public VendorController(IVendorService vendorService,IReportService reportService)
        {
            _vendorService = vendorService;
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVendorsReports()
        {
            var model = await _vendorService.GetVendorsWithReportsAsync();
            return Ok(model);
        }
    }
}
