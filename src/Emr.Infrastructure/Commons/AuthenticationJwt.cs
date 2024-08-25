using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Emr.Infrastructure.Commons
{
    public class AuthenticationJwt
    {
        public string GenerateJwtToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("your_secret_key_sdgdsfgsdgdanh1231213");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "test"),
                new Claim(ClaimTypes.Role, "Admin")
            }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = "yourdomain.com",
                Audience = "yourdomain.com",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
