using Microsoft.IdentityModel.Tokens;
using PrimevalAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimevalAPI.Services {

    public class ServicesToken {
        public string GenerateToken(Repository User) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokrnDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, User.NickName),
                    new Claim(ClaimTypes.Email, User.Email),
                    new Claim(ClaimTypes.Role, User.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokrnDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
