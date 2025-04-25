using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Models;
using IMSApi.Dtos.Image;

namespace IMSApi.Interfaces
{
    public interface IImageRepository
    {
        Task<ImageDto> GetByIdAsync(int id);


         Task<Image> CreateAsync(Image image);  

         Task<bool> ImageExists(int id);

         Task<Image> AssignToStaff(int id, AssignImageDto imageDto);

         Task<List<AssignImageDetailsDto>> GetAssignedImages(int id);
    }
}