using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Exceptions;
using ReportApp.DAL.Repository;
using System.Security.Claims;

namespace ReportApp.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Report> _reportRepo;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReportService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor,
            UserManager<AppUsers> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _reportRepo = unitOfWork.GetRepository<Report>();
            _userManager = userManager;
            _mapper = mapper;            
        }

        public async Task<ReportResponseDto> AddReportAsync(ReportRequestDto modelRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AppUsers userExists = await _userManager.FindByIdAsync(userId);

            if (userExists == null)
            {
                //throw new UserNotFoundException( Guid.Parse(userId) );
                throw new Exception("User not found!");
            }

            var newReport = _mapper.Map<Report>(modelRequest);

            var createdReport = await _reportRepo.AddAsync(newReport);

            if (createdReport == null)
            {
                throw new ReportNotFoundException(newReport.ReportId);
            }

            var toReturn = _mapper.Map<ReportResponseDto>(createdReport);

            return toReturn;

        }

        public async Task DeleteReportAsync(Guid reportId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUsers user = await _userManager.FindByIdAsync( userId );

            if(user is null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            Report report = await _reportRepo.GetSingleByAsync(r=>r.ReportId == reportId);
            if (report is null)
            {
                throw new ReportNotFoundException(reportId);
            }
            await _reportRepo.DeleteAsync(report);
            
        }

        public async Task<IEnumerable<Report>> GetAllReportsAsync()
        {
            var reports = await _reportRepo.GetAllAsync();

            if (!reports.Any())
            {
                throw new InvalidOperationException("No reports found");
            }

            return reports;
        }

        public (Report ReportResult, string message) GetReport(int employeeID, int reportID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>>  GetUserReports()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AppUsers user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            var userReports = _reportRepo.GetQueryable(r => r.UserId.ToString() == userId.ToString()).OrderBy(i => i.ReportId);

            if (userReports is null)
            {
                throw new Exception($"User with {userId} does not have any report");
            }

            return userReports;
        }

        public async Task<ReportResponseForUpdateDto> UpdateReportAsync(ReportRequestForUpdateDto modelRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            AppUsers user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            var userReport = await _reportRepo.GetSingleByAsync(r => r.ReportId == modelRequest.Id);

            if (userReport is null)
            {
                throw new ReportNotFoundException(modelRequest.Id);
            }
            
            _mapper.Map(modelRequest, userReport);
            //CCreateMap<Report, ReportResponseForUpdateDto>();  
            Report reportUpdated = await _reportRepo.UpdateAsync(userReport);
            var result = _mapper.Map<ReportResponseForUpdateDto>(reportUpdated);

            return result;
        }
    }
}
