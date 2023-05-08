using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Services;
using ReportApp.BLL.ServicesContract;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost]
        [Route("add-report")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> CreateUserReport([FromBody] ReportRequestDto modelRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _reportService.AddReportAsync(modelRequest);

            return StatusCode(201, result);

        }

        
        [HttpGet]
        [Route("get-all-reports")]
        [Authorize(Roles = "Organization")]
        public async Task<IActionResult> GetAllReports()
        {
            var result = await _reportService.GetAllReportsAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-user-reports")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetReports()
        {
            var result = await _reportService.GetUserReports();

            return Ok(result);
        }

        [HttpPut]
        [Route("update-user-report")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UpdateUserReport([FromBody]ReportRequestForUpdateDto modelRequest)
        {
            var result = await _reportService.UpdateReportAsync(modelRequest);
            
            return NoContent();
        }

        [HttpDelete]
        [Route("delete-report")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeleteReport(Guid reportId)
        {
            await _reportService.DeleteReportAsync(reportId);

            return NoContent();
        }

    }
}
