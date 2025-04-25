using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using Microsoft.EntityFrameworkCore;
using IMSApi.Dtos.Financial;

namespace IMSApi.Repository
{
    public class FinancialRepository : IFinancialRepository
    {
        private readonly AppDBContext _context;

        public FinancialRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Financial> CreateAsync(Financial financial)
        {
            await _context.Financial.AddAsync(financial);
            await _context.SaveChangesAsync();
            return financial;
        }

        public async Task<FinancialDto?> GetByIdAsync(int id)
        {
            return await _context.Financial.Where(f => f.Id == id)
         .Select(f => new FinancialDto
         {
             Id = f.Id,
             Amount = f.Amount,
             TransactionDate = f.TransactionDate,
             Description = f.Description,
             PatientName = f.Patient.Name
         })
         .FirstOrDefaultAsync();
        }

        public async Task<List<Financial>> GetFinanceByPatientIdAsync(int id)
        {
            return await _context.Financial.Where(p => p.PatientId == id).ToListAsync();
        }

        public async Task<Financial> UpdatePaymentStatus(int id, UpdatePaymentDto paymentDto)
        {
            var financial = await _context.Financial.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (financial == null)
            {
                return null;
            }

            financial.PaymentStatus = paymentDto.PaymentStatus;

            _context.Financial.Update(financial);
            await _context.SaveChangesAsync();

            return financial;
        }
    }
}