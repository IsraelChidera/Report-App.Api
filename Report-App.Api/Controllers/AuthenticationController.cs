using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.ServicesContract;
using ReportApp.Infrastructure.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }



        [HttpPost]
        [Route("register-organization")]
        [SwaggerOperation(
            Summary = "register an organization",
            Description = "Register an organization and return a model used for logins"                   
        )]
        [SwaggerResponse(201, "Organization was created successfully.", typeof(object))]
        [SwaggerResponse(400, "The request was invalid.", null)]             
        public async Task<IActionResult> CreateOrganization(OrganizationForRegistrationDto organization)
        {
            var response = await _authenticationService.RegisterOrganization(organization);
            return Ok(response);
        }




        [HttpPost("register-employee-by-an-organization")]
        [Authorize(Roles = "Organization")]
        [SwaggerOperation(
            Summary = "register an employee",
            Description = "Register an employee via an authenticated organization and return a model used for logins"            
        )]
        [SwaggerResponse(201, "Employee was created successfully.", typeof(object))]
        [SwaggerResponse(400, "The request was invalid.", null)]        
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForRegistrationDto employee)
        {
            var response = await _authenticationService.RegisterEmployee(employee);
            return Ok(response);
        }



        [HttpPost("login")]
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "login as either an organization or an employee",
            Description = "login as either an organization or an employee. Tokens are created that are used to login successfully"
        )]
        [SwaggerResponse(201, "Login successful", typeof(object))]
        [SwaggerResponse(400, "The request was invalid.", null)]        
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authenticationService.ValidateUser(user))
            {
                return Unauthorized();
            }

            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "SuperAdmin")
            };*/

            return Ok(new { Token = await _authenticationService.CreateToken() });
        }

    }
}
