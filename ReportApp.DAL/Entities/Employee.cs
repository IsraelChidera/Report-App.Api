using ReportApp.BLL.Entities;
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
    
        public string FullName { get; set; }
              
        public string Email { get; set; }    
        
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
                
    }
}
