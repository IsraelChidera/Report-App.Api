using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Name must be greater than 3 in length")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]        
        public string Email { get; set; }        

        
    }
}
