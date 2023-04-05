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

        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        /*[ForeignKey("AppUsers")]
        public Guid UserId { get; set; }

        public AppUsers User { get; set; }*/

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
