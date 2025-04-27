using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using IMSApi.Dtos.Appointment;
using Microsoft.EntityFrameworkCore;

namespace IMSApi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDBContext _context;

        public AppointmentRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            return await _context.Appointment.Where(p => p.Id == id)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientName = a.Patient.Name,
                PatientId = a.PatientId,
                DoctorName = a.Doctor.Name,
                DoctorId = a.DoctorId,
                Date = a.Date,
                Description = a.Description,
                Status = a.Status,
                CreatedAt = a.CreatedAt,
            }).FirstOrDefaultAsync();
        }

        public async Task<List<AppointmentDto?>> GetAllByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointment.Where(a => a.DoctorId == doctorId)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientName = a.Patient.Name,
                PatientId = a.PatientId,
                DoctorName = a.Doctor.Name,
                DoctorId = a.DoctorId,
                Date = a.Date,
                Description = a.Description,
                Status = a.Status,
                CreatedAt = a.CreatedAt,
            }).ToListAsync();
        }

        public async Task<List<AppointmentDto?>> GetAllByPatientIdAsync(int patientId)
        {
            return await _context.Appointment.Where(a => a.PatientId == patientId)
            .Select(a => new AppointmentDto
            {
                Id = a.Id,
                PatientName = a.Patient.Name,
                PatientId = a.PatientId,
                DoctorName = a.Doctor.Name,
                DoctorId = a.DoctorId,
                Date = a.Date,
                Description = a.Description,
                Status = a.Status,
                CreatedAt = a.CreatedAt,
            }).ToListAsync();
        }

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            await _context.Appointment.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

    }
}