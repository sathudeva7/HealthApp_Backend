using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Models;
using IMSApi.Dtos.Appointment;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppDBContext _context;

        private readonly IAppointmentRepository _appointmentRepository;

        private readonly IPatientRepository _patientRepository;

        public AppointmentController(AppDBContext context, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _context = context;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        [HttpPost("{PatientId}")]
        public async Task<IActionResult> Create([FromRoute] int PatientId, [FromBody] AppointmentDto appointmentDto){
            if (!await _patientRepository.PatientExists(PatientId)) {
                return BadRequest("Patient does not exist");
            }

            var appointment = appointmentDto.ToAppointmentFromCreate(PatientId);

            await _appointmentRepository.CreateAsync(appointment);

            return Ok(appointment);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet("doctor/{doctorId:int}")]
        public async Task<IActionResult> GetAllByDoctorId([FromRoute] int doctorId)
        {

            var appointment = await _appointmentRepository.GetAllByDoctorIdAsync(doctorId);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        [HttpGet("patient/{patientId:int}")]
        public async Task<IActionResult> GetAllByPatientId([FromRoute] int patientId)
        {

            var appointment = await _appointmentRepository.GetAllByPatientIdAsync(patientId);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

    }
}