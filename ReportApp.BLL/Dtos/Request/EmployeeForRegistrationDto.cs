using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos.Request
{
    public record EmployeeForRegistrationDto
    {
        public string FullName { get; init; }

        public string UserName { get; init; }

        public string Email { get; init; }

        public string PhoneNumber { get; init; }

        public string Address { get; init; }

        public string Password { get; init; }
    }
}
