using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Appointment;

namespace IMSApi.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<AppointmentDto?> GetByIdAsync(int id); 

        Task<List<AppointmentDto?>> GetAllByPatientIdAsync(int id);

        Task<List<AppointmentDto?>> GetAllByDoctorIdAsync(int id);

        Task<Appointment> CreateAsync(Appointment appointment);
    }
}