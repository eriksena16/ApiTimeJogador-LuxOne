using LuxOne.Infrastructure.Contract.InfrastructureContract.Security;
using LuxOne.Infrastructure.Security.Extension.ExtensionSecurity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LuxOne.Infrastructure.Security.JwtAuthorization
{
    public class JwtAuthorizationService : IJwtAuthotizationService
    {
        private readonly BearerSecurityKey _bearerSecurityKey;
        public JwtAuthorizationService(IOptionsMonitor<BearerSecurityKey> bearerSecurityKey)
        {
            _bearerSecurityKey = bearerSecurityKey.CurrentValue;
        }

        public async Task<string> Generate()
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_bearerSecurityKey.JwtSecurityKey);
            //var key = Encoding.ASCII.GetBytes("ab197302-a31d-4ab9-a8c4-83a7a7c7928b");
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Erik Sena"),
                    new Claim(ClaimTypes.Role, "Manager"),
                    new Claim("Time", "Cadastro"),
                }),
                Expires = DateTime.UtcNow.AddHours(2), //tempo
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return await Task.FromResult(jwtSecurityTokenHandler.WriteToken(token));
        }
    }
}
