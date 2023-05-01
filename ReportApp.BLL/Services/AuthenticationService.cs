using AutoMapper;
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
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(UserManager<AppUsers> userManager, IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _organizationRepo = _unitOfWork.GetRepository<Organization>();
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
            var userExists = _userManager.FindByEmailAsync(employeeRequest.Email);

            if (userExists != null)
            {
                throw new EmailNotFoundException(employeeRequest.Email);
            }

            var employeeResult = _mapper.Map<AppUsers>(employeeRequest);

            var newEmployee = await _userManager.CreateAsync(employeeResult, employeeRequest.Password);

            if (newEmployee.Succeeded)
            {
                await _userManager.AddToRoleAsync(employeeResult, "Employee");
                _mapper.Map<Employee>(employeeRequest);
            }

            return newEmployee;
        }


        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {

            _user = await _userManager.FindByEmailAsync(userForAuth.Email);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
            {
                throw new Exception("Invalid username");
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

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("REPORTAPISECRET") ?? "Fk24632Pz3gyJLYeYqJ6D8qELyNPUubr8vstypCgfMAC8Jyb3B");
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, _user.UserName),
               new Claim(ClaimTypes.Role, "SuperAdmin")
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
