using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using IMSApi.Dtos.Patient;
using Microsoft.EntityFrameworkCore;

namespace IMSApi.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDBContext _context;
        public PatientRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patient.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patient.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            await _context.Patient.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync(int id, UpdatePatientDto patientDto)
        {
            var existingPatient = await _context.Patient.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPatient == null)
            {
                return null;
            }

            existingPatient.Name = patientDto.Name;
            existingPatient.Email = patientDto.Email;
            existingPatient.Address = patientDto.Address;
            existingPatient.Phone = patientDto.Phone;
            existingPatient.Conditions = patientDto.Conditions;
            existingPatient.Diagnosis = patientDto.Diagnosis;

            await _context.SaveChangesAsync();
            return existingPatient;
        }

        public Task<bool> PatientExists(int id)
        {
            return _context.Patient.AnyAsync(e => e.Id == id);
        }

        public async Task<Patient> GetByEmailAsync(string email)
        {
            return await _context.Patient.FirstOrDefaultAsync(u => u.Email == email);
        }


    }


}