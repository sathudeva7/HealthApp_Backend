using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Models;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using IMSApi.Dtos.AppointmentSlot;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/appointment-slots")]
    public class AppointmentSlotController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IAppointmentSlotRepository _appointmentSlotRepository;

        public AppointmentSlotController(AppDBContext context, IAppointmentSlotRepository appointmentSlotRepository)

        {
            _context = context;
            _appointmentSlotRepository = appointmentSlotRepository;
        }

        // GET: api/appointment-slots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentSlot>>> GetAllSlots()
        {
            var slots = await _context.AppointmentSlots.ToListAsync();
            return Ok(slots);
        }

        // POST: api/appointment-slots
        [HttpPost]
        public async Task<ActionResult<AppointmentSlot>> CreateSlot([FromBody] AppointmentSlotDto slot)
        {
            var appointmentSlot = slot.ToAppointmentSlotFromCreate();
            await _appointmentSlotRepository.CreateAsync(appointmentSlot);

            return Ok(appointmentSlot);
        }

        // GET: api/appointment-slots/{id}
        [HttpGet("doctor/{doctorId:int}")]
        public async Task<ActionResult<AppointmentSlot>> GetAllSlotsByDoctorIdAsync(int doctorId, [FromQuery] DateTime? startTime,[FromQuery] DateTime? endTime)
        {
            var slot = await _appointmentSlotRepository.GetAllSlotsByDoctorIdAsync(doctorId, startTime, endTime);
            if (slot == null)
                return NotFound();

            return Ok(slot);
        }
    }
}
