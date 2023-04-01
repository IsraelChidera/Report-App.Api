using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;
using ReportApp.Infrastructure.Dtos;
using System.Data;

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

        //[Authorize(Roles = "Vendor")]
        [HttpGet]
        [Route("all-vendors")]
        public async Task<IActionResult> GetVendors()
        {
            var model = await _vendorService.GetAllVendors();

            return Ok(model);
        }

        [HttpGet]
        [Route("get-vendor-by-id")]
        public async Task<IActionResult> GetVendor(string vendorId)
        {
            var id = new Guid(vendorId.ToString());
            var vendor = await _vendorService.GetVendorById(id.ToString());

            return Ok(vendor);
        }

        [HttpPost]
        //[Authorize(Roles = "Vendor")]
        [Route("add-vendor-report")]
        public async Task<IActionResult> AddVendorReport([FromBody]CreateVendorReportsRequest report)
        {
             var result = await _vendorService.CreateVendorReport(report);

            return StatusCode(201, result);
        }

        //[HttpDelete("{id:guid}")]
        [HttpDelete]
        [Route("delete-vendor-report")]
        public async Task<IActionResult> DeleteVendorReport(Guid vendorId, Guid reportId)
        {
            await _vendorService.DeleteVendorReportAsync(vendorId, reportId);
            
            return NoContent();
        }

        //[HttpPut("{id:guid}")]
        [HttpPut]
        [Route("update-vendor-report")]
        public async Task<IActionResult> UpdateVendorReport([FromBody]CreateVendorReportsRequest request)
        {
            await _vendorService.UpdateVendorReport(request);

            return NoContent();
        }

        [HttpGet]
        [Route("get-vendor-all report")]
        public IActionResult GetAllVendorReports(string vendorId)
        {
            var id = new Guid(vendorId);
            var report = _vendorService.GetAllVendorReports(id);
            return Ok(report);
        }

    }
}
