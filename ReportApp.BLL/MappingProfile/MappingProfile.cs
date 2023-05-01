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
            
           
            CreateMap<CreateVendorReportsRequest, Report>();

            CreateMap<ReportRequestDto, Report>();            
            CreateMap<Report, ReportResponseDto>();

            CreateMap<ReportRequestForUpdateDto, ReportResponseForUpdateDto>();            

            CreateMap< ReportRequestForUpdateDto, Report>();

            CreateMap<Report, ReportResponseForUpdateDto>();

            CreateMap<OrganizationForRegistrationDto, Organization>();
            CreateMap< OrganizationForRegistrationDto, AppUsers>();
            CreateMap<EmployeeForRegistrationDto, AppUsers>();
            CreateMap<OrganizationForRegistrationDto, Organization>();
            CreateMap<EmployeeForRegistrationDto, Employee>();
        }
    }
}
