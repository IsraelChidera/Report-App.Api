using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos.Request;
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
        [Route("add-report")]
        public async Task<IActionResult> CreateUserReport([FromBody] ReportRequestDto modelRequest)
        {
            var model = await _reportService.AddReportAsync(modelRequest);

            return StatusCode(201, model);

        }

    }
}
