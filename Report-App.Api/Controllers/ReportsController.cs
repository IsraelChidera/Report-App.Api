using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.BLL.ServicesContract;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Adds a new report for an employee",
            Description = "Adds a new report for an employee with the specified details.",
            OperationId = "CreateUserReport",
            Tags = new[] { "Reports" }
        )]
        [SwaggerResponse(200, "The report was added successfully.", typeof(object))]
        [SwaggerResponse(400, "The request was invalid.", null)]
        public async Task<ActionResult<(string, ReportResponseDto)>> CreateUserReport([FromBody] ReportRequestDto modelRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _reportService.AddReportAsync(modelRequest);

            return Ok(new { message = response.Item1, report = response.Item2 });
        }



                
        [HttpGet]
        [Route("all-employees-reports")]
        [Authorize(Roles = "Organization, Admin, SuperAdmin")]
        [SwaggerOperation(
            Summary = "Get all reports by all employees in an organization",
            Description = "Get all employees' reports with their specified details."           
        )]
        [SwaggerResponse(200, "A list of all employee reports", typeof(IEnumerable<ReportResponseDto>))]
        [SwaggerResponse(401, "Unauthorized")]
        [SwaggerResponse(404, "No reports found")]
        public async Task<ActionResult<IEnumerable<ReportResponseDto>>> GetAllReports()
        {
            var result = await _reportService.GetAllReportsAsync();

            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }



        
        [HttpGet]
        [Route("employee-reports")]
        [Authorize(Roles = "Employee, Organization")]
        [SwaggerOperation(Summary = "Get all reports submitted by an employee", Description = "This endpoint returns all reports submitted by an employee.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of reports submitted by an employee", Type = typeof(IEnumerable<ReportResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request was invalid or could not be understood.")]
        public async Task<ActionResult<IEnumerable<ReportResponseDto>>> GetEmployeeReports()
        {
            var response = await _reportService.GetUserReportsAsync();

            if (response == null)
            {
                BadRequest();
            }

            return Ok(response);
        }




        [HttpGet("employee-report/{reportId}")]
        [SwaggerOperation(Summary = "Get a report submitted by an employee by its ID", Description = "This endpoint returns a report submitted by an employee by its ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the report submitted by an employee with the specified ID", Type = typeof(ReportResponseDto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "The request was invalid or could not be understood.")]        
        public async Task<IActionResult> GetEmployeeReportById(Guid reportId)
        {
            var response = await _reportService.GetReportAsync(reportId);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }




        
        [HttpPut]
        [Route("update-employee-report")]
        [Authorize(Roles = "Employee")]
        [SwaggerOperation(
            Summary = "Update an existing employee's report",
            Description = "Updates an existing report for an employee with the specified details.",
            OperationId = "CreateUserReport",
            Tags = new[] { "Reports" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated report and a success message.", typeof((string, ReportResponseForUpdateDto)))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data provided.")]
        public async Task<ActionResult<(string, ReportResponseForUpdateDto)>> UpdateEmployeeReport([FromBody] ReportRequestForUpdateDto modelRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _reportService.UpdateUserReportAsync(modelRequest);

            return Ok(new { message = response.Item1, report = response.Item2 });
        }




        
        [HttpDelete("employee-report/{reportId}")]
        [Authorize(Roles = "Employee")]
        [SwaggerOperation(
            Summary = "Delete a report for an employee",
            Description = "Delete an employee report with the specified Id."            
        )]
        [SwaggerResponse(200, "The report was successfully deleted.", typeof(ReportResponseDto))]
        [SwaggerResponse(400, "The report could not be found.")]
        public async Task<IActionResult> DeletEmployeeeReportById(Guid reportId)
        {
            var result = await _reportService.DeleteReportAsync(reportId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

    }
}
