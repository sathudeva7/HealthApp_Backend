using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Models
{
    public class AppointmentSlot
    {
        public int Id { get; set; }

        public int DoctorId { get; set; } //foreign key

        //Navigation Property
        public Staff? Doctor { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; }
        
        
    }
}