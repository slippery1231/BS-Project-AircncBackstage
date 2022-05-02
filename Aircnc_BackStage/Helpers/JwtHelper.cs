using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Aircnc_BackStage.Helpers
{
    public class JwtHelper
    {
        public static string Issuer = "Aircnc";
        public static SymmetricSecurityKey SecurityKey => new(Encoding.UTF8.GetBytes("1Zl4h9703IzROidasgfegkK3@f4po1dfkdsfmdskfmdskfms"));

        public string GenerateToken(string username)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, username));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            var userClaimIdentity = new ClaimsIdentity(claims);
            var signCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                //發行者
                Issuer = Issuer,
                //發行時間
                IssuedAt = DateTime.UtcNow,
                //訂閱者
                Subject = userClaimIdentity,
                //有效時間
                Expires = DateTime.UtcNow.AddHours(8).AddHours(3),
                SigningCredentials = signCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptior);
            var serializeToken = tokenHandler.WriteToken(securityToken);
            return serializeToken;

        }
    }
}
