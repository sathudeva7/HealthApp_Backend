using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IMSApi.Models;

namespace IMSApi.Services
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(Staff staff);
    }
}