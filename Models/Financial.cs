using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApi.Models
{
    public class Financial
    {
        public int Id { get; set; } //primary key

        public int? PatientId { get; set; } //foreign key

        //Navigation Property
        public Patient? Patient { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }


        
    }
}