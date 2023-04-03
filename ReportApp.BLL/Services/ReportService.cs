using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Repository;

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

            if (userExists == null)
            {
                throw new Exception("user does not exist");
            }
            var newReport = _mapper.Map<Report>(modelRequest);

            var createdReport = await _reportRepo.AddAsync(newReport);

            if (createdReport == null)
            {
                throw new Exception("Unable to create report");
            }

            var toReturn = _mapper.Map<ReportResponseDto>(createdReport);

            return toReturn;

        }

        public async Task DeleteReportAsync(Guid userId, Guid reportId)
        {
            AppUsers user = await _userManager.FindByIdAsync(userId.ToString());

            if(user is null)
            {
                throw new Exception("user does not exist");
            }

            Report report = await _reportRepo.GetSingleByAsync(r=>r.ReportId == reportId);
            if (report is null)
            {
                throw new Exception("report does not exist");
            }
            await _reportRepo.DeleteAsync(report);
            
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            var reports = await _reportRepo.GetAllAsync();

            if (!reports.Any())
            {
                throw new InvalidOperationException("Reports is empty");
            }

            return reports;
        }

        public (Report ReportResult, string message) GetReport(int employeeID, int reportID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetUserReports(Guid userId)
        {
            var userReports = _reportRepo.GetQueryable(r => r.UserId.ToString() == userId.ToString()).OrderBy(i => i.ReportId);

            if (userReports is null)
            {
                throw new Exception($"User with {userId} does not have any report");
            }

            return userReports;
        }

        public async Task<ReportResponseForUpdateDto> UpdateReportAsync(ReportRequestForUpdateDto modelRequest)
        {
            AppUsers user = await _userManager.FindByIdAsync(modelRequest.UserId.ToString());

            if (user == null)
            {
                throw new Exception("user is not found");
            }

            var userReport = await _reportRepo.GetSingleByAsync(r => r.ReportId == modelRequest.Id);

            if (userReport is null)
            {
                throw new Exception("User does not have a report");
            }
            
            _mapper.Map(modelRequest, userReport);
            //CCreateMap<Report, ReportResponseForUpdateDto>();  
            Report reportUpdated = await _reportRepo.UpdateAsync(userReport);
            var result = _mapper.Map<ReportResponseForUpdateDto>(reportUpdated);

            return result;
        }
    }
}
