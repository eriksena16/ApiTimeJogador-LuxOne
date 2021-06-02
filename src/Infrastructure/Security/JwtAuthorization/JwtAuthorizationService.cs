using LuxOne.Infrastructure.Contract.InfrastructureContract.Security;
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
        public async Task<string> Generate()
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            // var key = await _keyVaultSecretManager.Get(_bearerSecurityKey.JwtSecurityKey);
            var key = Encoding.ASCII.GetBytes("ab197302-a31d-4ab9-a8c4-83a7a7c7928b");
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                   /* new Claim(ClaimTypes.Name, userModel.Username),
                    new Claim(ClaimTypes.Role, userModel.Role),*/
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
