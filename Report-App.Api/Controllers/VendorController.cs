using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;
using ReportApp.Infrastructure.Dtos;

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
        [Route("get-vendors-reports")]
        public async Task<IActionResult> GetVendorsReports()
        {
            var model = await _vendorService.GetVendorsWithReportsAsync();
            return Ok(model);
        }

        [HttpGet]
        [Route("all-vendors")]
        public async Task<IActionResult> GetVendors()
        {
            var model = await _vendorService.GetAllVendors();

            return Ok(model);
        }

        [HttpGet]
        [Route("get-vendor")]
        public async Task<IActionResult> GetVendor(Guid vendorId)
        {
            var vendor = await _vendorService.GetVendorById(vendorId);

            return Ok(vendor);
        }

        [HttpPost]
        [Route("add-vendor-report")]
        public async Task<IActionResult> AddVendorReport([FromBody]CreateVendorReportsRequest report)
        {
             var result = await _vendorService.CreateVendorReport(report);

            return StatusCode(201, result);
        }

    }
}
