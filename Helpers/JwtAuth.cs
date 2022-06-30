using MarcusDesafio.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MarcusDesafio.Helpers
{
    public class JwtAuth
    {
            public static string GenerateToken(User user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("%fc105ba75146fd0/80ce91be53d181d02");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(5),

                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
        
}
}
