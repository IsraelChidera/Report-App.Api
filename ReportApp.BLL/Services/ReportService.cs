using ReportApp.BLL.ServicesContract;
using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.Services
{
    public class ReportService : IReportService
    {
        public Task<(bool check, string message)> AddReportAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(bool check, string message)> DeleteReportAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Report> GetAllReports()
        {
            throw new NotImplementedException();
        }

        public (Report ReportResult, string message) GetReport(int employeeID, int reportID)
        {
            throw new NotImplementedException();
        }

        public Task<(bool check, string message)> UpdateReportAsync()
        {
            throw new NotImplementedException();
        }
    }
}
