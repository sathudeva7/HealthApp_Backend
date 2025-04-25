using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Financial
{
    public class CreateFinanceDto
    {
        public int? PatientId { get; set; } //foreign key

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string PaymentStatus { get; set; }

        public string Description { get; set; }
    }
}