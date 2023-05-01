using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Organization
    {
        [Column("OrganizationId")]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Organization name must be greater than 3 in length")]
        public string OrganizationName { get; set; }        

        [Required]
        [MinLength(3, ErrorMessage = "Organization name must be greater than 3 in length")]
        public string Industry { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Address must be greater than 3 in length")]
        public string? Address { get; set; }
    }
}
