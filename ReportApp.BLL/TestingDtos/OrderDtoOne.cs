using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.TestingDtos
{
    public class OrderDtoOne
    {
        public decimal Total { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public IList<OrderDetailDtoOne> OrderDetails { get; set; }
    }
}
