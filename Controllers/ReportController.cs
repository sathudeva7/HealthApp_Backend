using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IMSApi.Data;
using IMSApi.Models;
using IMSApi.Dtos.Report;
using IMSApi.Mappers;
using IMSApi.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IReportRepository _reportRepo;

        private readonly IImageRepository _imageRepo;

        public ReportController(AppDBContext context, IReportRepository reportRepo, IImageRepository imageRepo)
        {
            _reportRepo = reportRepo;
            _context = context;
            _imageRepo = imageRepo;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reports = await _reportRepo.GetAllReportsAsync(); 

            var reportDto = reports.Select(s => s.ToReportDto());

            return Ok(reportDto);
        }

        [Authorize]
        [HttpPost("{ImageId:int}")]
        public async Task<IActionResult> Create([FromRoute] int ImageId, [FromBody] CreateReportDto reportDto) {

            if (!await _imageRepo.ImageExists(ImageId)) {
                return BadRequest("Image does not exist");
            }

            var report = reportDto.ToReportFromCreate(ImageId);

            await _reportRepo.CreateReportAsync(report);

            return Ok(report.ToReportDto());
        }




    }
}