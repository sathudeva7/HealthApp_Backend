using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApi.Models
{
    public class Image
    {
        public int Id { get; set; } //primary key

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? UploadedBy { get; set; }

        public Staff UploadedStaff { get; set; }

        public string FilePath { get; set; }

        public int? AssignedTo { get; set; }

        public Staff AssignedStaff { get; set; }

        public int? ReportId { get; set; }

        public List<Report> Reports { get; set; } = new List<Report>();

        public DateTime UploadDate { get; set; }

    }
}