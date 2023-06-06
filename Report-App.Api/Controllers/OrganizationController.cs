using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }


        [HttpGet]
        [Route("all-organizations")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        [SwaggerOperation(
            Summary = "Get all organizations",
            Description = "Get all authenticated organizations with their details."
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns all organizations", typeof(IEnumerable<Organization>))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data provided.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error")]
        public async Task<IActionResult> GetAllOrganization()
        {
            var response = await _organizationService.GetAllOrganization();

            return StatusCode(201, response);
        }
    }
}
