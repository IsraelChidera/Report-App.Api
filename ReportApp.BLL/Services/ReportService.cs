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

        public async Task<(string, ReportResponseDto)> AddReportAsync(ReportRequestDto modelRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AppUsers userExists = await _userManager.FindByIdAsync(userId);

            if (userExists == null)
            {
                //throw new UserNotFoundException( Guid.Parse(userId) );
                throw new Exception("User not found!");
            }

            var newReport = _mapper.Map<Report>(modelRequest);
            newReport.EmployeeId = Guid.Parse(userExists.Id);
            var createdReport = await _reportRepo.AddAsync(newReport);

           
            var toReturn = _mapper.Map<ReportResponseDto>(createdReport);

            if (createdReport == null)
            {
                return ("Failed attempt to create a new report", toReturn);
            }

            return ("Report card created successfully", toReturn);

        }

        public async Task<string> DeleteReportAsync(Guid reportId)
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

            return "Report deleted sucessfully";
        }

        public async Task<IEnumerable<ReportResponseDto>> GetAllReportsAsync()
        {
            var reports = await _reportRepo.GetAllAsync();

            if (!reports.Any())
            {
                throw new InvalidOperationException("No reports found");
            }

            var toReturn = _mapper.Map<List<ReportResponseDto>>(reports);
            return toReturn;
        }       

        public async Task<IEnumerable<ReportResponseDto>>  GetUserReportsAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            AppUsers user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            var userReports = _reportRepo.GetQueryable(r => r.EmployeeId.ToString() == user.Id.ToString()).OrderBy(i => i.ReportId);

            if (userReports is null)
            {
                throw new Exception($"User with {userId} does not have any report");
            }

            var toReturn = _mapper.Map< IEnumerable<ReportResponseDto> >(userReports);

            return toReturn;
        }

        public async Task<(string, ReportResponseForUpdateDto)> UpdateUserReportAsync(ReportRequestForUpdateDto modelRequest)
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
            Report reportUpdated = await _reportRepo.UpdateAsync(userReport);
            var result = _mapper.Map<ReportResponseForUpdateDto>(reportUpdated);

            if(reportUpdated == null)
            {
                return ("Failed attempt to update report card", result);
            }

            return ("Report updated successfully", result);
        }
    
        public async Task<ReportResponseDto> GetReportAsync(Guid reportId)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            var report = await _reportRepo.GetSingleByAsync(x => x.ReportId == reportId);
            if (report == null)
            {
                throw new ReportNotFoundException(reportId);
            }

            var toReturn = _mapper.Map<ReportResponseDto>(report);
            return toReturn;
        }


    }
}
