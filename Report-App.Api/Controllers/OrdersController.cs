using Microsoft.AspNetCore.Mvc;
using ReportApp.BLL.Dtos;
using ReportApp.BLL.ServicesContract;

namespace Report_App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {        
        private readonly IOrderService _orderService;        

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("add-order")]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
           var result = await _orderService.CreateOrderAsync(order);

            return Ok(result);
        }

        [HttpGet]
        [Route("get-all-orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet]
        [Route("get-order")]
        public async Task<IActionResult> GetOrder(Guid Id)
        {
            var result = await _orderService.GetOrder(Id);
            return Ok(result);
        }
    }
}
