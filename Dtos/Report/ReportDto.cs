using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Report
{
    public class ReportDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? PatientId { get; set; }

        public int? ImageId { get; set; }

        public string StaffName { get; set; }
                
        public int? CreatedBy { get; set; }

    }
}