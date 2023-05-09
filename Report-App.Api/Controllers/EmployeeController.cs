using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;

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
        [Route("get-employees")]
        [Authorize(Roles = "Organization, SuperAdmin, Admin")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllOrganizationWorker()
        {
            var response = await _employeeService.GetAllEmployees();

            return Ok(response);
        }


    }
}
