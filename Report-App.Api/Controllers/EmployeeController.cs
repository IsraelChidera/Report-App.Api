using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService= employeeService;
        }


        [HttpGet]
        [Route("all-employees")]
        [Authorize(Roles = "Organization, SuperAdmin, Admin")]
        [SwaggerOperation(Summary = "Get all employees from an organization", Description = "This endpoint allows an authenticated organization " +
            "get all authenticated employees")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of employees", typeof(object) )]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request parameters")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllOrganizationWorker()
        {
            var response = await _employeeService.GetAllEmployees();

            return Ok(response);
        }


    }
}
