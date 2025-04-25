using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Staff;

namespace IMSApi.Interfaces
{
    public interface IStaffRepository
    {
        Task<List<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> CreateStaffAsync(Staff staff);
        Task<Staff> UpdateStaffAsync(int id, UpdateStaffDto staff);

        Task<LoginResponseDto> LoginAsync(string email, string password, string userType);

    }
}