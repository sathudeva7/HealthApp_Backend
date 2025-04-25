using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Report;

namespace IMSApi.Interfaces
{
    public interface IReportRepository
    {

       Task<Report> CreateReportAsync(Report report);

        Task<List<Report>> GetAllReportsAsync();
    }
}