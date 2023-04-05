using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Dtos
{
    public class OrderDto
    {
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid CustomerId { get; set; }
        public ICollection<OrderDetailsDto> OrderDetails { get; set; }
    }
}
