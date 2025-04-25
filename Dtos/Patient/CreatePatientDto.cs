using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Patient
{
    public class CreatePatientDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string ProfileImage { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public string Conditions { get; set; }

    }
}