using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Report;
using IMSApi.Dtos.Staff;

namespace IMSApi.Dtos.Image
{
    public class ImageDto
    {
        public int Id { get; set; } //primary key

        public int? PatientId { get; set; }

        public int? UploadedBy { get; set; }

        public int? AssignedTo { get; set; }

        public string StaffName { get; set; }


        public string FilePath { get; set; }

        
        public DateTime UploadDate { get; set; }

        public List<ReportDto> Reports { get; set; }

    }
}