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
       
        public string OrganizationEmail { get; set; }

        public string Address { get; set; }

        public int NumberOfEmployees { get; set; }
    }
}
