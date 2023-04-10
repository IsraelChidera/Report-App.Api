using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Enums
{
    public enum OrderStatus
    {
        PendingPayment,
        Paid,
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
