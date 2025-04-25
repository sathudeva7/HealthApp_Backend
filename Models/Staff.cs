using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSApi.Models
{
    public class Staff
    {
        public int Id { get; set; } //primary key

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public string Phone { get; set; }

        public List<Image> UploadedImages { get; set; } = new List<Image>();
        public List<Report> CreatedReports { get; set; } = new List<Report>();
    }
}