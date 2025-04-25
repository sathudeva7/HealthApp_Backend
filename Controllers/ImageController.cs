using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMSApi.Data;
using IMSApi.Mappers;
using IMSApi.Dtos.Image;
using IMSApi.Interfaces;
using IMSApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace IMSApi.Controllers
{
    [ApiController]
    [Route("api/image")]
    public class ImageController : ControllerBase
    {
        private readonly AppDBContext _context;

        private readonly IImageRepository _imageRepository;

        private readonly IPatientRepository _patientRepository;

        public ImageController(AppDBContext context, IImageRepository imageRepository, IPatientRepository patientRepository) {
            _context = context;
            _imageRepository = imageRepository;
            _patientRepository = patientRepository;

        }


        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var image = await _imageRepository.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(image);
        }

        [Authorize]
        [HttpPost("{PatientId:int}")]
        public async Task<IActionResult> Create([FromRoute] int PatientId, [FromBody] CreateImageDto imageDto){

            if (!await _patientRepository.PatientExists(PatientId)) {
                return BadRequest("Patient does not exist");
            }
            var image = imageDto.ToImageFromCreate(PatientId);
            
            await _imageRepository.CreateAsync(image);

            return CreatedAtAction(nameof(GetById), new { id = image.Id }, image.ToImageDto());

        }

        [Authorize]
        [HttpPut("assign/staff/{ImageId:int}")]
        public async Task<IActionResult> AssignToStaff([FromRoute] int ImageId, [FromBody] AssignImageDto imageDto)
        {
            if (!await _imageRepository.ImageExists(ImageId)) {
                return BadRequest("Image does not exist");
            }
            //var image = imageDto.ToImageFromAssignStaff(imageDto, ImageId);

            var image = await _imageRepository.AssignToStaff(ImageId, imageDto);

            return Ok(image.ToImageDto());
        }

        [Authorize]
        [HttpGet("assigned/{staffId:int}")]
        public async Task<IActionResult> GetAssignedImages([FromRoute] int staffId)
        {
            var images = await _imageRepository.GetAssignedImages(staffId);

            return Ok(images);
        }
    }
}