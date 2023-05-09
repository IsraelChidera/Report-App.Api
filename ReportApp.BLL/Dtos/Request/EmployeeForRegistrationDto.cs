using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos.Request
{
    public record EmployeeForRegistrationDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Full name must be greater than 5 in length")]
        public string FullName { get; init; }

        [Required]
        [MinLength(3, ErrorMessage = "Username must be greater than 3 in length")]
        public string UserName { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [MinLength(9, ErrorMessage = "Phone number must be equals to or greater than 9 in length")]
        [MaxLength(11, ErrorMessage = "Phone number must be equals to or less than 11 in length")]
        public string PhoneNumber { get; init; }

        [Required]
        [MinLength(5, ErrorMessage = "Address must be greater than 5 in length")]
        public string Address { get; init; }

        public string Password { get; init; }
    }
}
