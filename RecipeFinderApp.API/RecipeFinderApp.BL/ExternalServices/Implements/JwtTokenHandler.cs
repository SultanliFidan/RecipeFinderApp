using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.ExternalServices.Implements
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        readonly JwtOptions opt;
        public JwtTokenHandler(IOptions<JwtOptions> _opt)
        {
            opt = _opt.Value;
        }
        public string CreateToken(User user, int hours = 36)
        {
            List<Claim> claims = [
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
           //new Claim(ClaimTypes.Role,user.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            //new Claim(ClaimTypes.FullName,user.Fullname)
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.SecretKey));
            SigningCredentials cred = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken secToken = new(
                issuer: opt.Issuer,
                audience: opt.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(hours),
                signingCredentials: cred
            );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }
    }
}
