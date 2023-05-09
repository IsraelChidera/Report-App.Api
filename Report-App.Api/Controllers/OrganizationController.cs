using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService= organizationService;
        }

        [HttpGet]
        [Route("get-all-organizations")]
        [Authorize("SuperAdminm, Admin")]
        public async Task<IActionResult> GetAllOrganization()
        {
            var response = await _organizationService.GetAllOrganization();

            return StatusCode(201, response);
        }
    }
}
