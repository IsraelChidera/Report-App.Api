using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ReportApp.BLL.Entities;
using ReportApp.BLL.ServicesContract;
using ReportApp.Infrastructure.Dtos;

namespace ReportApp.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<AppUsers> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var userExists = await _userManager.FindByEmailAsync(userForRegistration.Email);

            if (userExists != null)
            {
                throw new Exception("Email exists already");
            }
            var userResult = _mapper.Map<AppUsers>(userForRegistration);
            var result = await _userManager.CreateAsync(userResult, userForRegistration.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(userResult, userForRegistration.Roles);
            }

            return result;
        }

    }
}
