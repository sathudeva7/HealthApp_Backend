using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        List<Staff?> Staffs { get; set; }


    }
}