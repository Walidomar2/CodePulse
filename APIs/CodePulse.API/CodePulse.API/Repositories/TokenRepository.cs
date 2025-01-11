using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodePulse.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string CreateJwtToken(IdentityUser user, List<string> roles)
        {
            // 1 - Creating Claims 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // 2 - Creating a Symmetric security key 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // 3 - Creating the credentials using the generated key and encrypt it 
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4 - Generating the Token
            var token = new JwtSecurityToken(
               issuer: _configuration["Jwt:Issuer"],
               audience: _configuration["Jwt:Audience"],
               claims: claims,
               expires: DateTime.Now.AddMinutes(15),
               signingCredentials: credentials
               );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
