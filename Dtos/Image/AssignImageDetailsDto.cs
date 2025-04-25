using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Report;

namespace IMSApi.Dtos.Image
{
    public class AssignImageDetailsDto
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public string StaffName { get; set; }

        public string PatientName { get; set; }

        public int PatientAge { get; set; }

        public List<ReportDto> Reports { get; set; }

    }
}