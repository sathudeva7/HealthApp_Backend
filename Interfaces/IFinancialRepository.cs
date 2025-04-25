using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Financial;

namespace IMSApi.Interfaces
{
    public interface IFinancialRepository
    {
        Task<Financial> CreateAsync(Financial financial);

        Task<FinancialDto> GetByIdAsync(int id);

        Task<List<Financial>> GetFinanceByPatientIdAsync(int PatientId);

        Task<Financial> UpdatePaymentStatus(int Id, UpdatePaymentDto paymentDto);
    }
}