using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Patient;

namespace IMSApi.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id); 
        Task<Patient> CreateAsync(Patient patient);
        Task<Patient?> UpdateAsync(int id,UpdatePatientDto patientDto);
        
        Task<bool> PatientExists(int id);

        Task<Patient> GetByEmailAsync(string email);

    }
}