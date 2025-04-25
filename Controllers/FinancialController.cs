using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Dtos.Financial;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/finance")]
    public class FinancialController : ControllerBase
    {
        private readonly AppDBContext _context;

        private readonly IFinancialRepository _financialRepository;

        private readonly IPatientRepository _patientRepository;

        public FinancialController(AppDBContext context, IFinancialRepository financialRepository, IPatientRepository patientRepository)
        {
            _context = context;
            _financialRepository = financialRepository;
            _patientRepository = patientRepository;
        }

        [Authorize]
        [HttpPost("{PatientId:int}")]
        public async Task<IActionResult> Create([FromRoute] int PatientId, [FromBody] CreateFinanceDto financialDto){
            if (!await _patientRepository.PatientExists(PatientId)) {
                return BadRequest("Patient does not exist");
            }
            var financial = financialDto.ToFinancialFromCreate(PatientId);

            await _financialRepository.CreateAsync(financial);

            return CreatedAtAction(nameof(GetById), new { id = financial.Id }, financial.ToFinancialDto());
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var financial = await _financialRepository.GetByIdAsync(id);

            if (financial == null)
            {
                return NotFound();
            }

            return Ok(financial);
        }

        [Authorize]
        [HttpGet("patient/{PatientId:int}")]
        public async Task<IActionResult> GetByPatientId([FromRoute] int PatientId)
        {
            var financial = await _financialRepository.GetFinanceByPatientIdAsync(PatientId);

            if (financial == null)
            {
                return NotFound();
            }

            return Ok(financial);
        }

        [Authorize]
        [HttpPut("financial/{Id:int}")]
        public async Task<IActionResult> UpdatePaymentStatus([FromRoute] int Id, [FromBody] UpdatePaymentDto paymentDto)
        {
            var financial = await _financialRepository.UpdatePaymentStatus(Id, paymentDto);

            if (financial == null)
            {
                return NotFound();
            }

            return Ok(financial);
        }



        
    }
}