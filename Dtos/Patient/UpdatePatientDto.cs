using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Patient
{
    public class UpdatePatientDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Conditions { get; set; }

        public string Diagnosis { get; set; }

    }
}