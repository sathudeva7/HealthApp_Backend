using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSApi.Services
{
    public class JwtOptions
    {
        public string Issuer { get; init; }

        public string Audience { get; init; }

        public string SecretKey { get; init; }
    }
}