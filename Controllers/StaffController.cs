using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Dtos.Staff;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IStaffRepository _staffRepo;



        public StaffController(AppDBContext context, IStaffRepository staffRepo)
        {
            _staffRepo = staffRepo;
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var staffs = await _staffRepo.GetAllStaffAsync();
            var staffDto = staffs.Select(s => s.MapToStaffsDto());
            return Ok(staffDto);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var staff = await _staffRepo.GetStaffByIdAsync(id);

            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff.MapToStaffsDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaffDto staffDto)
        {
            var staff = staffDto.MapToStaffCreateDto();
            await _staffRepo.CreateStaffAsync(staff);
            return CreatedAtAction(nameof(GetById), new { id = staff.Id }, staff.MapToStaffsDto());
        }

        //login staff
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var staff = await _staffRepo.LoginAsync(loginDto.Email, loginDto.Password, loginDto.UserType);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
                
        }



    }
    }