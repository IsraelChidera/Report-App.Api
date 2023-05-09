using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
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
        [Route("add-employee-report")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<(string, ReportResponseDto)>> CreateUserReport([FromBody] ReportRequestDto modelRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _reportService.AddReportAsync(modelRequest);

            return Ok(new {message = response.Item1, report = response.Item2});
        }

        
        [HttpGet]
        [Route("get-all-employees-reports")]
        [Authorize(Roles = "Organization")]
        public async Task<ActionResult<IEnumerable<ReportResponseDto> >> GetAllReports()
        {
            var result = await _reportService.GetAllReportsAsync();

            if(result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("get-employee-reports")]
        [Authorize(Roles = "Employee, Organization")]
        public async Task<ActionResult< IEnumerable<ReportResponseDto> >> GetEmployeeReports()
        {
            var response = await _reportService.GetUserReportsAsync();

            if(response == null)
            {
                BadRequest();
            }

            return Ok(response);
        }

        [HttpPut]
        [Route("update-employee-report")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<(string, ReportResponseForUpdateDto)>> UpdateEmployeeReport([FromBody]ReportRequestForUpdateDto modelRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _reportService.UpdateUserReportAsync(modelRequest);

            return Ok(new { message = response.Item1, report = response.Item2 });
        }

        [HttpDelete]
        [Route("delete-employee-report-by-id")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> DeletEmployeeeReport(Guid reportId)
        {
            var result = await _reportService.DeleteReportAsync(reportId);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);            
        }

    }
}
