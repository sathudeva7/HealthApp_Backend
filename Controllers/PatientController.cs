using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Dtos.Patient;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using IMSApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace IMSApi.Controllers
{
    [Route("api/patient")]
    [ApiController]

    public class PatientController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IPatientRepository _patientRepo;

        private readonly AuthService _authService;

        public PatientController(AppDBContext context, IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepo.GetAllAsync();
            var patientDto = patients.Select(s => s.MapToPatientsDto());
            return Ok(patientDto);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient.MapToPatientDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto patientDto)
        {
            var existingPatient = await _patientRepo.GetByEmailAsync(patientDto.Email);

            if (existingPatient != null)
            {
                return BadRequest("Email already exists");
            }
            var patient = patientDto.MapToPatientCreateDto();
            var newPatient = await _patientRepo.CreateAsync(patient);
            // var token = await  _authService.GenerateJwtToken(newPatient);
            // Console.WriteLine(token);
            return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient.MapToPatientDto());
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePatientDto patientDto)
        {
            var patient = await _patientRepo.UpdateAsync(id, patientDto);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient.MapToPatientDto());
        }



    }
}