﻿using ReportApp.BLL.Dtos.Request;
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
        Task<(string, ReportResponseDto)> AddReportAsync(ReportRequestDto modelRequest);
        Task<string> DeleteReportAsync(Guid reportId);
        Task<(string, ReportResponseForUpdateDto)> UpdateUserReportAsync(ReportRequestForUpdateDto modelRequest);        
        Task<IEnumerable<ReportResponseDto>> GetAllReportsAsync();
        Task<IEnumerable<ReportResponseDto>> GetUserReportsAsync();
        Task<ReportResponseDto> GetReportAsync(Guid reportId);
    }
}
