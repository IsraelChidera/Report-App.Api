using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Entities.Exceptions;
using ReportApp.DAL.Repository;
using ReportApp.Infrastructure.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReportApp.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private AppUsers? _user;
        private readonly IRepository<Organization> _organizationRepo;
        private readonly IRepository<Employee> _employeeRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(UserManager<AppUsers> userManager, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _organizationRepo = _unitOfWork.GetRepository<Organization>();
            _employeeRepo = _unitOfWork.GetRepository<Employee>();
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IdentityResult> RegisterOrganization(OrganizationForRegistrationDto organizationRequest)
        {

            var userExists = await _userManager.FindByEmailAsync(organizationRequest.Email);

            if (userExists != null)
            {
                throw new Exception("Email is already taken");
            }

            var organizationResult = _mapper.Map<AppUsers>(organizationRequest);

            var organization = await _userManager.CreateAsync(organizationResult, organizationRequest.Password);

            var mappedOrganization = _mapper.Map<Organization>(organizationRequest);
            await _organizationRepo.AddAsync(mappedOrganization);

            if (organization.Succeeded)
            {
                await _userManager.AddToRoleAsync(organizationResult, "Organization");
            }

            return organization;

        }

        public async Task<IdentityResult> RegisterEmployee(EmployeeForRegistrationDto employeeRequest)
        {
            var organizationExists = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (organizationExists == null)
            {
                throw new Exception("Organization is not authenticated");
            }

            var org = await _userManager.FindByNameAsync(organizationExists);
            if(org == null)
            {
                throw new OrganizationNotFound(organizationExists);
            }

            var userExists = await _userManager.FindByEmailAsync(employeeRequest.Email);

            if (userExists != null)
            {
                throw new Exception("Email is already taken");
            }

            var employeeResult = new AppUsers
            {
                Email = employeeRequest.Email,
                PasswordHash = employeeRequest.Password,
                UserName = employeeRequest.UserName,
                OrganizationName = organizationExists,
            };

            var newEmployee = await _userManager.CreateAsync(employeeResult, employeeRequest.Password);

            var organization = await _organizationRepo.GetSingleByAsync(x => x.OrganizationName == org.OrganizationName);

            if(organization == null)
            {
                throw new Exception("organization not found");
            }

            var mappedEmployee = _mapper.Map<Employee>(employeeRequest);
            mappedEmployee.OrganizationId = organization.Id;
            await _employeeRepo.AddAsync(mappedEmployee);
            

            if (newEmployee.Succeeded)
            {
                await _userManager.AddToRoleAsync(employeeResult, "Employee");
            }

            return newEmployee;
        }


        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {

            _user = await _userManager.FindByEmailAsync(userForAuth.Email);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
            {
                throw new Exception("Invalid Email or Password");
            }

            return result;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private static SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("REPORTAPISECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Id.ToString()),
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }


    }
}
