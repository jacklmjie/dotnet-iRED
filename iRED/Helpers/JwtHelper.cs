using iRED.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iRED.Helpers
{
    /// <summary>
    /// Jwt辅助操作类
    /// </summary>
    public class JwtHelper
    {
        /// <summary>
        /// 生成JwtToken
        /// </summary>
        public static string CreateToken(Claim[] claims, JwtSettings jwt)
        {
            string secret = jwt.Secret;
            if (secret == null)
            {
                throw new Exception("创建JwtToken时Secret为空");
            }
            SecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime now = DateTime.Now;
            double days = Math.Abs(jwt.ExpireDays);
            DateTime expires = now.AddDays(days);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = jwt.Audience,
                Issuer = jwt.Issuer,
                SigningCredentials = credentials,
                NotBefore = now,
                IssuedAt = now,
                Expires = expires
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
