using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Report> _reportRepo;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IMapper _mapper;

        public ReportService(IUnitOfWork unitOfWork,
            UserManager<AppUsers> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _reportRepo = unitOfWork.GetRepository<Report>();
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ReportResponseDto> AddReportAsync(ReportRequestDto modelRequest)
        {
            AppUsers userExists = await _userManager.FindByIdAsync(modelRequest.UserId.ToString());

            if(userExists is null)
            {
                throw new Exception("user does not exist");
            }
            var newReport = _mapper.Map<Report>(modelRequest);

            var createdReport = await _reportRepo.AddAsync(newReport);

            if(createdReport is null)
            {
                throw new Exception("Unable to create report");
            }

            var toReturn = _mapper.Map<ReportResponseDto>(createdReport);

            return toReturn;            

        }

        public Task<(bool check, string message)> DeleteReportAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public (Report ReportResult, string message) GetReport(int employeeID, int reportID)
        {
            throw new NotImplementedException();
        }

        public Task<(bool check, string message)> UpdateReportAsync()
        {
            throw new NotImplementedException();
        }
    }
}
