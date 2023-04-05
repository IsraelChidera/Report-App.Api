using AutoMapper;
using ReportApp.BLL.Dtos;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.BLL.Entities;
using ReportApp.DAL.Entities;
using ReportApp.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, AppUsers>();
            //_mapper.Map<AppUsers>(vendorForRegistration);
            CreateMap<VendorForRegistration, AppUsers>(); 

            CreateMap<CustomerForRegistration, AppUsers>();
           
            CreateMap<CreateVendorReportsRequest, Report>();

            CreateMap<ReportRequestDto, Report>();            
            CreateMap<Report, ReportResponseDto>();

            CreateMap<ReportRequestForUpdateDto, ReportResponseForUpdateDto>();            

            CreateMap< ReportRequestForUpdateDto, Report>();

            CreateMap<Report, ReportResponseForUpdateDto>();

            //
            CreateMap<ProductResponse, CreateProductRequest>();

            CreateMap<CreateProductRequest, ProductResponse>();

            CreateMap<Product, ProductResponse>();
            CreateMap<Product, CreateProductRequest>();
            CreateMap< CreateProductRequest, Product>();

            CreateMap<ProductResponse, UpdateProductRequest>();

            //
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

        }
    }
}
