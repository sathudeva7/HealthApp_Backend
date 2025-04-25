using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using IMSApi.Models;
using Microsoft.Extensions.Configuration;
using IMSApi.Dtos.Patient;

namespace IMSApi.Services
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(LoginUserDto staff)
        {
            var handler = new JwtSecurityTokenHandler();

            // Get private key from configuration
            var privateKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }

            var keyBytes = Encoding.UTF8.GetBytes(privateKey);
            if (keyBytes.Length < 32)
            {
                throw new InvalidOperationException("JWT Key must be at least 256 bits.");
            }

            // Create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, staff.Id.ToString()),
                new Claim(ClaimTypes.Name, staff.Name ?? "Unknown"),
                new Claim(ClaimTypes.Email, staff.Email ?? "Unknown"),
            };

            // Create signing credentials
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256);

            // Token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"], // Add Issuer
                Audience = _configuration["Jwt:Audience"], // Add Audience
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = credentials
            };

            // Generate the token
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}
