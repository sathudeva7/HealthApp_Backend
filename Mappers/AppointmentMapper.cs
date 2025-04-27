using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Appointment;
using IMSApi.Models;

namespace IMSApi.Mappers
{
    public static class AppointmentMapper
    {
        public static Appointment ToAppointmentFromCreate(this AppointmentDto appointmentDto, int patientId)
        {
            return new Appointment
            {
                PatientId = patientId,
                DoctorId = appointmentDto.DoctorId,
                Date = appointmentDto.Date,
                Description = appointmentDto.Description,
                Status = appointmentDto.Status,
                CreatedAt = appointmentDto.CreatedAt,
            };
        }

        public static AppointmentDto ToAppointmentDto(this Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                Date = appointment.Date,
                Description = appointment.Description,
                Status = appointment.Status,
                CreatedAt = appointment.CreatedAt,
            };
        }
    }
}