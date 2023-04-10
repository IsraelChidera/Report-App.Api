using ReportApp.BLL.Dtos;
using ReportApp.BLL.TestingDtos;
using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IOrderService
    {
        Task<string> CreateOrderAsync(OrderDto order, Guid userID);

        Task<IEnumerable<Order>> GetOrders();

        Task<OrderDto> GetOrder(Guid Id);

    }
}
