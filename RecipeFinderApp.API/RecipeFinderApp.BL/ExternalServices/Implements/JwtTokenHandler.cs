using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
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
        readonly UserManager<User> userManager;
        public JwtTokenHandler(IOptions<JwtOptions> _opt,UserManager<User> _userManager)
        {
            userManager = _userManager;
            opt = _opt.Value;
        }
        public async Task<string> CreateToken(User user, int hours = 36)
        {
            var roles = await userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();
            List<Claim> claims = [
                new Claim(ClaimTypes.Name, user.Fullname),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, role),
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
