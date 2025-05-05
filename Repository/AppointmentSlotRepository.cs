using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using IMSApi.Dtos.AppointmentSlot;
using Microsoft.EntityFrameworkCore;


namespace IMSApi.Repository
{
    public class AppointmentSlotRepository : IAppointmentSlotRepository
    {
        private readonly AppDBContext _context;

        public AppointmentSlotRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<AppointmentSlot?> CreateAsync(AppointmentSlot appointmentSlot)
        {
            await _context.AppointmentSlots.AddAsync(appointmentSlot);
            await _context.SaveChangesAsync();
            return appointmentSlot;
        }

        public async Task<List<AppointmentSlotDto>> GetAllSlotsByDoctorIdAsync(int doctorId, DateTime? startDate, DateTime? endDate)
        {
            return await _context.AppointmentSlots
                .Where(a => a.DoctorId == doctorId &&
                            a.StartTime >= startDate &&
                            a.StartTime <= endDate)
                .Select(a => new AppointmentSlotDto
                {
                    Id = a.Id,
                    DoctorName = a.Doctor.Name,
                    DoctorId = a.DoctorId,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    IsAvailable = a.IsAvailable
                })
                .ToListAsync();
        }

    }
}