using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Patient;
using IMSApi.Models;
using BCrypt.Net;



namespace IMSApi.Mappers
{
    public static class PatientMappers
    {
        public static PatientDto MapToPatientsDto(this Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email,
                Address = patient.Address,
                Phone = patient.Phone,
                Conditions = patient.Conditions,
                Images = patient.Images.Select(i => i.ToImageDto()).ToList(),
            };
        }

        public static PatientDto MapToPatientDto(this Patient patient)
        {
            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                Email = patient.Email,
                Address = patient.Address,
                Phone = patient.Phone,
                Gender = patient.Gender,
                Age = patient.Age,
                ProfileImage = patient.ProfileImage,
                Conditions = patient.Conditions,
                Diagnosis = patient.Diagnosis,
                Images = patient.Images.Select(i => i.ToImageDto()).ToList(),
            };
        }

        public static Patient MapToPatientCreateDto(this CreatePatientDto patientDto)
        {
            return new Patient
            {
                Name = patientDto.Name,
                Email = patientDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(patientDto.Password),
                Address = patientDto.Address,
                Phone = patientDto.Phone,
                Gender = patientDto.Gender,
                Age = patientDto.Age,
                ProfileImage = patientDto.ProfileImage,
                Diagnosis = "",
                Conditions = patientDto.Conditions

            };

        }
    }
}