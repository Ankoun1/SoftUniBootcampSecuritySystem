using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace SoftUniBootcampSecuritySystem.Api.Infrastructure
{
    public class ClaimsPrincipalExtensions
    {
        private IConfiguration configuration;

        public ClaimsPrincipalExtensions(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string SecurityCommunication((string,string) user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Item1),
            new Claim(ClaimTypes.Role, user.Item2)
            };

            var token = new JwtSecurityToken
            (
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}