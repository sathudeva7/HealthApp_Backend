using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.AppointmentSlot;

namespace IMSApi.Interfaces
{
    public interface IAppointmentSlotRepository
    {
        Task<AppointmentSlot?> CreateAsync(AppointmentSlot appointmentSlot);

        Task<List<AppointmentSlotDto?>> GetAllSlotsByDoctorIdAsync(int id, DateTime? startDate, DateTime? endDate);
    }
}