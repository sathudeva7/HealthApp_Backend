using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using IMSApi.Dtos.Staff;
using Microsoft.EntityFrameworkCore;
using IMSApi.Services;
using BCrypt.Net;
using IMSApi.Dtos.Patient;

namespace IMSApi.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly AppDBContext _context;

        private readonly AuthService _authService;


        public StaffRepository(AppDBContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<List<Staff>> GetAllStaffAsync()
        {
            return await _context.Staff.ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _context.Staff.FindAsync(id);
        }

        public async Task<Staff> CreateStaffAsync(Staff staff)
        {
            await _context.Staff.AddAsync(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(int id, UpdateStaffDto staffDto)
        {
            var existingStaff = await _context.Staff.FirstOrDefaultAsync(p => p.Id == id);

            if (existingStaff == null)
            {
                return null;
            }

            existingStaff.Name = staffDto.Name;
            existingStaff.Email = staffDto.Email;
            existingStaff.Password = staffDto.Password;
            existingStaff.Phone = staffDto.Phone;

            await _context.SaveChangesAsync();
            return existingStaff;
        }

        public async Task<LoginResponseDto?> LoginAsync(string email, string password, string userType)
        {
            dynamic user;

            if (userType == "Staff")
            {
                user = await _context.Staff.FirstOrDefaultAsync(u => u.Email == email);
            }
            else if (userType == "Patient")
            {
                user = await _context.Patient.FirstOrDefaultAsync(u => u.Email == email);
            }
            else
            {
                return null; // Invalid userType
            }

            // Check if user exists
            if (user == null)
            {
                return null; // User not found
            }

            // Check if the password matches (assuming passwords are hashed)
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return null; // Invalid password
            }

            var loginUserDto = new LoginUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };

            // Generate JWT token
            var token = _authService.GenerateJwtToken(loginUserDto);

            return new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = userType,
                Token = token
            };
        }


    }
}