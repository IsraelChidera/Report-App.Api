using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IReportService
    {
        Task<ReportResponseDto> AddReportAsync(ReportRequestDto modelRequest);
        Task<(bool check, string message)> DeleteReportAsync();
        Task<(bool check, string message)> UpdateReportAsync();
        (Report ReportResult, string message) GetReport(int employeeID, int reportID);
        IEnumerable<Report> GetAllReports();
    }
}
