using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace IMSApi.Models
{
    public class Patient 
    {
        public int Id { get; set; } //primary key  

        
        public string Name { get; set; }

        
        public string Email { get; set; }

        public string Password { get; set; }

        
        public string Address { get; set; }

        
        public string Phone { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Conditions { get; set; }

        public string Diagnosis { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCost { get; set; }

        public string ProfileImage { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();
        public ICollection<Financial> FinancialRecords { get; set; } = new List<Financial>();

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}