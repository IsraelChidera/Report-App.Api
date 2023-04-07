using ReportApp.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }                       
        public string? CustomerName { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
