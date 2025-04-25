using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Staff
{
    public class StaffDto
    {
        public int Id { get; set; } //primary key  
        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}