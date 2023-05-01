using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos.Request
{
    public class OrganizationForRegistrationDto
    {
    
        public string OrganizationName { get; set; }

        public string Username { get; set; }
       
        public string Email { get; set; }

        public string Address { get; set; }        

        public string Industry { get; set; }
        
        public string Password { get; init; }
    }
}
