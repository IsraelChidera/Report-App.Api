using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.ServicesContract;
using ReportApp.Infrastructure.Dtos;

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


        [HttpPost("register-organization")]        
        public async Task<IActionResult> CreateOrganization(OrganizationForRegistrationDto organization)
        {
            var response = await _authenticationService.RegisterOrganization(organization);
            return Ok(response);
        }

        [HttpPost("register-employee-by-an-organization")]
        [Authorize(Roles = "Organization")]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForRegistrationDto employee)
        {
            var response = await _authenticationService.RegisterEmployee(employee);
            return Ok(response);
        }

        [HttpPost("login")]
        [AllowAnonymous]
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
