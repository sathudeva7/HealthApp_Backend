using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Image
{
    public class CreateImageDto
    {
        public int? UploadedBy { get; set; }

        public string FilePath { get; set; }
        
    }
}