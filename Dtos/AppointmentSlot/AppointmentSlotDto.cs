using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.AppointmentSlot
{
    public class AppointmentSlotDto
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        


    }
}