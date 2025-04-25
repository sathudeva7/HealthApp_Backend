using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Financial
{
    public class FinancialDto
    {
        public int Id { get; set; } //primary key

        public int? PatientId { get; set; } //foreign key

        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }
        public string PatientName { get; set; }
    }
}