using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.AppointmentSlot;
using IMSApi.Models;

namespace IMSApi.Mappers
{
    public static class AppointmentSlotMapper
    {
        public static AppointmentSlot ToAppointmentSlotFromCreate(this AppointmentSlotDto appointmentSlotDto)
        {
            return new AppointmentSlot
            {
                DoctorId = appointmentSlotDto.DoctorId,
                StartTime = appointmentSlotDto.StartTime,
                EndTime = appointmentSlotDto.EndTime,
                IsAvailable = appointmentSlotDto.IsAvailable,
                CreatedAt = appointmentSlotDto.CreatedAt,
            };
        }
    }
}