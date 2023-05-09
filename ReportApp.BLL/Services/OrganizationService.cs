using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Exceptions;
using ReportApp.DAL.Repository;
using System.Data.Common;
using System.Security.Claims;

namespace ReportApp.BLL.Services
{

    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Organization> _organizationRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUsers> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUsers> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork= unitOfWork;
            _userManager= userManager;
            _organizationRepo = _unitOfWork.GetRepository<Organization>();
            _mapper= mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Organization>> GetAllOrganization()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new UserNotFoundException( Guid.Parse(userId) );
            }

            var allOrganization = await _organizationRepo.GetAllAsync();
            return allOrganization;
        }
    }
}
