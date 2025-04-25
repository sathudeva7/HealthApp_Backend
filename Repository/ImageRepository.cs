using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Interfaces;
using IMSApi.Data;
using IMSApi.Dtos.Image;
using IMSApi.Mappers;
using IMSApi.Dtos.Report;
using Microsoft.EntityFrameworkCore;

namespace IMSApi.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppDBContext _context;
        public ImageRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Image> CreateAsync(Image image)
        {
            await _context.Image.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<ImageDto?> GetByIdAsync(int id)
        {
            return await _context.Image.Where(f => f.Id == id)
            .Select(f => new ImageDto
            {
                Id = f.Id,
                FilePath = f.FilePath,
                StaffName = f.AssignedStaff.Name,
                Reports = f.Reports.Select(i => new ReportDto { Id = i.Id, Content = i.Content, CreatedOn = i.CreatedOn, StaffName = i.CreatedStaff.Name }).ToList(),
            }).FirstOrDefaultAsync(p => p.Id == id);

            
        }

        public async Task<Image> AssignToStaff(int id, AssignImageDto imageDto)
        {
            var image = await _context.Image.FindAsync(id);

            image.AssignedTo = imageDto.AssignedTo;

            await _context.SaveChangesAsync();

            return image;

        }

        public Task<bool> ImageExists(int id)
        {
            return _context.Image.AnyAsync(e => e.Id == id);
        }

        public async Task<List<AssignImageDetailsDto?>> GetAssignedImages(int staffId)
        {
            return _context.Image.Where(i => i.AssignedTo == staffId)
            .Select(p => new AssignImageDetailsDto 
            {
                Id = p.Id,
                FilePath = p.FilePath,
                StaffName = p.AssignedStaff.Name,
                PatientName = p.Patient.Name,
                PatientAge = p.Patient.Age,
                Reports = p.Reports.Select(i => new ReportDto { Id = i.Id, Content = i.Content, CreatedOn = i.CreatedOn, StaffName = i.CreatedStaff.Name }).ToList()
            }).ToList();
        }
    }
}