using ReportApp.DAL.Entities;
using ReportApp.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IVendorService
    {       
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task<IEnumerable<VendorsWithReportsDto>> GetVendorsWithReportsAsync();
        Task<Vendor> GetVendorById(Guid vendorId);
        Task<ReportDto> CreateVendorReport(CreateVendorReportsRequest request);
    }
}
