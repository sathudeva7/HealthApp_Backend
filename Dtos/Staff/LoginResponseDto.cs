using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Dtos.Staff
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Token { get; set; }
    }
}