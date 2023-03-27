using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
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

        public AuthenticationService(UserManager<AppUsers> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
           /* var superAdmin = new AppUsers
            {
                UserName = "IsraelChidera",
                Email = "chiderahub@gmail.com",
                EmailConfirmed = true,
                PasswordHash = "Chidera@2023"
            };

            var superAdminSeedResult = await _userManager.CreateAsync(superAdmin, superAdmin.PasswordHash);

            if (superAdminSeedResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(superAdmin, superAdmin.);
            }*/
            //

            var userExists = await _userManager.FindByEmailAsync(userForRegistration.Email);

            if (userExists != null)
            {
                throw new Exception("Email already exists");
            }
            var userResult = _mapper.Map<AppUsers>(userForRegistration);
            var result = await _userManager.CreateAsync(userResult, userForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(userResult, userForRegistration.Roles);
            }

            return result;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            

            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            if (!result)
            {
                throw new Exception("Invalid");
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
