using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Dtos;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.BLL.TestingDtos;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Testing;
using ReportApp.DAL.Repository;
using System;
using static ReportApp.BLL.Dtos.OrderDto;

namespace ReportApp.BLL.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<OrderOne> _orderOneRepo;
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<OrderDetailOne> _orderDetailOneRepo;

        public OrderServices(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUsers> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _orderRepo = _unitOfWork.GetRepository<Order>();
            _orderOneRepo = _unitOfWork.GetRepository<OrderOne>();
            _productRepo = _unitOfWork.GetRepository<Product>();
            _orderDetailOneRepo = _unitOfWork.GetRepository<OrderDetailOne>();
        }

        public async Task<string> CreateOrderAsync(OrderDto order, Guid userID)
        {

            try
            {
                AppUsers userExists = await _userManager.FindByIdAsync(userID.ToString());

                if(userExists is null)
                {
                    throw new Exception("User not found");
                }
                
                var newOrder = new Order()
                {
                    CustomerName = $"{userExists.FirstName} {userExists.LastName}",
                    OrderDetails = (from item in order.Details
                                    select new OrderDetail()
                                    {
                                        ProductName = item.ProductName,
                                        ProductId = item.ProductId,
                                        Price = item.Price,
                                        Quantity = item.Quantity,
                                    }).ToList()
                };
                var createdOrder = await _orderRepo.AddAsync(newOrder);

                if (createdOrder == null)
                {
                    throw new Exception("Unable to create new order");
                }

                return "sucessfull";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                throw new Exception(ex.Source);
                throw new Exception(ex.StackTrace);
            }



        }

        public async Task<OrderDto> GetOrder(Guid Id)
        {
            try
            {
                var order = await _orderRepo.GetSingleByAsync(e => e.OrderId == Id,
                include: o => o.Include(r => r.OrderDetails), tracking: true);

                if (order is null)
                {
                    throw new Exception("Order is not found");
                }

                return new OrderDto()
                {
                    Details = from d in order.OrderDetails
                              select new Detail()
                              {
                                  ProductId = d.ProductId,
                                  ProductName = d.ProductName??"",
                                  Price = d.Price,
                                  Quantity = d?.Quantity ?? 0
                              }
                };

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                throw new Exception(ex.Source);
                throw new Exception(ex.StackTrace);
            }

        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var orders = await _orderRepo.GetAllAsync();

            return orders;
        }


    }
}
