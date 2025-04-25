using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IMSApi.Interfaces;
using IMSApi.Models;
using IMSApi.Data;


namespace IMSApi.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDBContext _context;

        public ReportRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Report>> GetAllReportsAsync()
        {
            return await _context.Report.ToListAsync();
        }

        public async Task<Report> CreateReportAsync(Report report)
        {
            await _context.Report.AddAsync(report);
            await _context.SaveChangesAsync();
            return report;
        }
    }
}