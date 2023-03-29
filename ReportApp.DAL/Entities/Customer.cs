using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Customer
    {
        [Column("CustomerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Customer name is a required field")]
        [MinLength(3, ErrorMessage = "Name should be more than 3 characters")]
        public string Name { get; set; }       
                
        public string? Address { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone is a required field")]
        [MinLength(9, ErrorMessage = "Phone number should be more than 9 characters")]
        public string Phone { get; set; }


        public IList<Report>? Reports { get; set; }
    }
}
