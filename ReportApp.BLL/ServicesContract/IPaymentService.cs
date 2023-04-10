using PayStack.Net;
using ReportApp.BLL.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IPaymentService
    {
        Task<TransactionInitializeResponse> MakePayment(PaymentRequestDto request);
    }
}
