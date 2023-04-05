using ReportApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(OrderDto order);

        IEnumerable<OrderDto> GetOrders(OrderDto order);

        Task GetOrderAsync(OrderDto order);

    }
}
