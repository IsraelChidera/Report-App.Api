using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Exceptions;
using ReportApp.DAL.Repository;
using System.Security.Claims;

namespace ReportApp.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, UserManager<AppUsers> userManager,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _employeeRepo = _unitOfWork.GetRepository<Employee>();
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                //throw new UserNotFoundException(Guid.Parse(userId));
                throw new Exception("Not authenticated to perform this operation");
            }


            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new UserNotFoundException(Guid.Parse(userId));
            }

            var employees = await _employeeRepo.GetAllAsync();


            return employees;
        }
    }
}
