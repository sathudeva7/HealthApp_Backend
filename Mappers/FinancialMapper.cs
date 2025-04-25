using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Financial;
using IMSApi.Models;


namespace IMSApi.Mappers
{
    public static class FinancialMapper
    {
        public static Financial ToFinancialFromCreate(this CreateFinanceDto dto, int patientId)
        {
            return new Financial
            {
                Amount = dto.Amount,
                PatientId = patientId,
                Description = dto.Description,
                PaymentStatus = dto.PaymentStatus,
                TransactionDate = dto.TransactionDate
            };
        }

        public static FinancialDto ToFinancialDto(this Financial financial)
        {
            return new FinancialDto
            {
                Id = financial.Id,
                Amount = financial.Amount,
                PatientId = financial.PatientId,
                PaymentStatus = financial.PaymentStatus,
                Description = financial.Description,
                TransactionDate = financial.TransactionDate
            };
        }
    }
}