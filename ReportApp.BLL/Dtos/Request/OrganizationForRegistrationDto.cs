using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos.Request
{
    public record OrganizationForRegistrationDto
    {
    
        public string OrganizationName { get; init; }

        public string Username { get; init; }
       
        public string Email { get; init; }

        public string Address { get; init; }        

        public string Industry { get; init; }
        
        public string Password { get; init; }
    }
}
