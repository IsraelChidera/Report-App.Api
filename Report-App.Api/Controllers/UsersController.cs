using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;
using ReportApp.DAL.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Report_App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUsers> _userManager;

        public UsersController(UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
        }

        
        [HttpGet]
        [Route("all-users")]
        /*[Authorize(Roles = "SuperAdmin, Admin, Organization")]*/
        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Get all users present in the app",
            Description = "Get all authenticated organizations and employees with their details."
        )]
        [SwaggerResponse(200, "The list of all app users.", typeof(IEnumerable<AppUsers>))]
        [SwaggerResponse(401, "Unauthorized.")]
        public async Task<IEnumerable<AppUsers>> GetAllAppUsers()
        {
            //return await _userManager.Users.ToListAsync();
            var s = "Employee";
            var result =  await _userManager.GetUsersInRoleAsync(s);
            if(result.Any())
            {
                return result;
            }

            return new List<AppUsers>();
            //return await _userManager.GetUsersInRoleAsync("Employees");
        }


    }
}
