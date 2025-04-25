using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Image;

namespace IMSApi.Mappers
{
    public static class ImageMapper
    {
        public static ImageDto ToImageDto(this Image image)
        {
            return new ImageDto
            {
                Id = image.Id,
                PatientId = image.PatientId,
                UploadedBy = image.UploadedBy,
                FilePath = image.FilePath,
                AssignedTo = image.AssignedTo,
                UploadDate = image.UploadDate,
                Reports = image.Reports.Select(i => i.ToReportDto()).ToList(),
            };
        }

        public static Image ToImageFromCreate(this CreateImageDto createImageDto, int patientId)
        {
            return new Image
            {
                PatientId = patientId,
                UploadedBy = createImageDto.UploadedBy,
                FilePath = createImageDto.FilePath,
               
            };
        }

        public static Image ToImageFromAssignStaff(this AssignImageDto assignImageDto, int imageId)
        {
            return new Image
            {
                Id = imageId,
                AssignedTo = assignImageDto.AssignedTo,

            };
        }
    }
}