using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
