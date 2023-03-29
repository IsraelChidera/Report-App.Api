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
        Task<(bool check, string message)> AddReportAsync();
        Task<(bool check, string message)> DeleteReportAsync();
        Task<(bool check, string message)> UpdateReportAsync();
        (Report ReportResult, string message) GetReport(int employeeID, int reportID);
        IEnumerable<Report> GetAllReports();
    }
}
