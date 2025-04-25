using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Staff;
using IMSApi.Models;
using BCrypt.Net;

namespace IMSApi.Mappers
{
    public static class StaffMappers
    {
        public static StaffDto MapToStaffsDto(this Staff staff)
        {
            return new StaffDto
            {
                Id = staff.Id,
                Name = staff.Name,
                Role = staff.Role,
                Email = staff.Email,
                Phone = staff.Phone
            };
        }

        public static Staff MapToStaffCreateDto(this CreateStaffDto staffDto)
        {
            return new Staff
            {
                Name = staffDto.Name,
                Email = staffDto.Email,
                Role = staffDto.Role,
                Password = BCrypt.Net.BCrypt.HashPassword(staffDto.Password),
                Phone = staffDto.Phone,
            };

        }
    }
}