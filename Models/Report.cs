using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Models
{
    public class Report
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? CreatedBy { get; set; }

        public Staff CreatedStaff { get; set; }

        public int? ImageId { get; set; }

        public Image Image { get; set; }

        
    }
}