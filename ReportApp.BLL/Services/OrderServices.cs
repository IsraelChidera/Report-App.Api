using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Dtos;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Exceptions;
using ReportApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IRepository<Order> _orderRepo;

        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUsers> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _orderRepo = _unitOfWork.GetRepository<Order>();
        }

        public async Task<string> CreateOrderAsync(OrderDto order)
        {
            AppUsers customerExists = await _userManager.FindByIdAsync(order.CustomerId.ToString());

            if(customerExists is null)
            {
                throw new UserNotFoundException(order.CustomerId);
            }

            var customer = order.CustomerId;

            if(customer.ToString() != customerExists.ToString())
            {
                throw new Exception("Does not match");
            }

            var newOrder = _mapper.Map<Order>(order);
            var createdOrder = await _orderRepo.AddAsync(newOrder);

            if (createdOrder == null)
            {
                throw new Exception("Unable to create new order");
            }

            return "sucessfull";
        }

        public Task GetOrderAsync(OrderDto order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDto> GetOrders(OrderDto order)
        {
            throw new NotImplementedException();
        }
    }
}
