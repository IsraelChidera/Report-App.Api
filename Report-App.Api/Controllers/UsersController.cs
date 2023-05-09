using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;

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
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IEnumerable<AppUsers>> GetAllAppUsers()
        {
            return await _userManager.Users.ToListAsync();
        }


    }
}
