using AutoMapper;
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
            

            /*var newReport = _mapper.Map<Report>(request);
            vendor.Reports.Add(newReport);

            var report = _mapper.Map<ReportDto>(newReport);*/
        }
    }
}
