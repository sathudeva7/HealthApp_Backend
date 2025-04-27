using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }             // foreign key
        public Patient Patient { get; set; }           // navigation property

        public int DoctorId { get; set; }              // foreign key
        public Staff Doctor { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }


        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


    }
}