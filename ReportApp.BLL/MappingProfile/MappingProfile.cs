using AutoMapper;
using ReportApp.BLL.Entities;
using ReportApp.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, AppUsers>();

            CreateMap<VendorForRegistration, AppUsers>();

            CreateMap<SellerForRegistration, AppUsers>();
        }
    }
}
