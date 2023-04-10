using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos.Request
{
    public class PaymentRequestDto
    {        
        public decimal Amount { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }            
        public Guid UserId { get; set; }
    }
}
