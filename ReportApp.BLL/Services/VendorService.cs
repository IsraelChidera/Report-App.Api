using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using ReportApp.DAL.Repository;
using ReportApp.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Services
{
    public class VendorService : IVendorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Vendor> _vendorRepo;
        public VendorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
            _vendorRepo = _unitOfWork.GetRepository<Vendor>();
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VendorsWithReportsDto>> GetVendorsWithReportsAsync()
        {
            return (await _vendorRepo.GetAllAsync(include: e => e.Include(r => r.Reports)))
                .Select(r=>new VendorsWithReportsDto
                {
                    FullName = r.Name,
                    VendorReports = r.Reports.Select(t=>new ReportDto
                    {
                        Location = t.Location,
                        ResourceAtRisk = t.ResourceAtRisk,
                        HazardDescription = t.HazardDescription,
                        HazardRating = t.HazardRating.ToString(),
                        AdditionalInfo = t.AdditionalInfo,
                        RiskImpact = t.RiskImpact.ToString(),
                        RiskProbability = t.RiskProbability.ToString(),
                        PreventiveMeasure = t.PreventiveMeasure.ToString(),
                    })
                });
        }
    }
}
