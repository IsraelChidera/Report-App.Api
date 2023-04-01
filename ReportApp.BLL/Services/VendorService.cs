using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReportApp.BLL.Entities;
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
        private readonly IRepository<Report> _reportRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUsers> _vendor;
        public VendorService(IUnitOfWork unitOfWork, UserManager<AppUsers> vendor, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _vendorRepo = _unitOfWork.GetRepository<Vendor>();
            _reportRepo = _unitOfWork.GetRepository<Report>();
            _vendor = vendor;
            _mapper = mapper;
        }

        public async Task<ReportDto> CreateVendorReport(CreateVendorReportsRequest request)
        {
            var vendor = await _vendorRepo.GetSingleByAsync(v => v.Id == request.VendorId,
                include: v => v.Include(r => r.Reports), tracking: true);

            if(vendor is null)
            {
                throw new Exception("Vendor is not found");
            }

            Report reportResult = vendor.Reports.FirstOrDefault(r => r.Id.ToString() == request.ReportId);

            var newReport = _mapper.Map<Report>(request);
            vendor.Reports.Add(newReport);
           await _unitOfWork.SaveChangesAsync();
            var toReturn = _mapper.Map<ReportDto>(newReport);
            return toReturn;
        }

        public async Task DeleteVendorReportAsync(Guid vendorId, Guid reportId)
        {
            var vendor = await _vendorRepo.GetSingleByAsync(v => v.Id == vendorId,
                include: v=>v.Include(r=>r.Reports), tracking: true);

            if(vendor is null)
            {
                throw new Exception("Vendor is not found");
            }

            var report = vendor?.Reports?.FirstOrDefault(r => r.Id == reportId);
            if(report is null)
            {
                throw new Exception("Vendor does not have report");
            }

            vendor?.Reports?.Remove(report);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<ReportDto> GetAllVendorReports(Guid vendorId)
        {
            var reports =  _reportRepo.GetQueryable(u => u.VendorId == vendorId).OrderBy(i => i.Id);

            if(reports is null)
            {
                throw new Exception("incorrect vendorid");
            }

            return _mapper.Map<IEnumerable<ReportDto>>(reports);
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            IEnumerable<Vendor> vendors = await _vendorRepo.GetAllAsync();

            if (!vendors.Any())
            {
                throw new InvalidOperationException("No vendor is found");
            }

            return vendors;
        }

        public async Task<Vendor> GetVendorById(string vendorId)
        {
            var vendorExists = await _vendorRepo.GetSingleByAsync(v => v.Id.ToString() == vendorId);
            
            if(vendorExists is null)
            {
                throw new InvalidOperationException("No vendor exist with that id");
            }

            return vendorExists;
        }

        

        public async Task<IEnumerable<VendorsWithReportsDto>> GetVendorsWithReportsAsync()
        {
            return (await _vendorRepo.GetAllAsync(include: e => e.Include(r => r.Reports)))
                .Select(r=>new VendorsWithReportsDto
                {
                    FullName = r.Name,
                    VendorReports = r.Reports.Select(t=>new VendorReportDto
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

        public async Task<ReportDto> UpdateVendorReport(CreateVendorReportsRequest request)
        {
            var vendor = await _vendorRepo.GetSingleByAsync(v => v.Id == request.VendorId,
                include: v => v.Include(r => r.Reports), tracking: true);

            if (vendor is null)
            {
                throw new Exception("vendor is not found");
            }

            var report = vendor.Reports.FirstOrDefault(r => r.Id.ToString() == request.ReportId);

            if(report == null)
            {
                throw new Exception("report is not found");
            }

            var updatedReport = _mapper.Map(request, report);
            await _unitOfWork.SaveChangesAsync();
            var toReturn = _mapper.Map<ReportDto>(updatedReport);
            return toReturn;            

        }


    }
}
