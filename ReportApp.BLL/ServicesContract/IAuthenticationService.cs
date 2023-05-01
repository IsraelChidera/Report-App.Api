using Microsoft.AspNetCore.Identity;
using ReportApp.BLL.Dtos.Request;
using ReportApp.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IAuthenticationService
    {
        
        Task<IdentityResult> RegisterOrganization(OrganizationForRegistrationDto organizationRequest);

        Task<IdentityResult> RegisterEmployee(EmployeeForRegistrationDto employeeRequest);

        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);        

        Task<string> CreateToken();
    }
}
