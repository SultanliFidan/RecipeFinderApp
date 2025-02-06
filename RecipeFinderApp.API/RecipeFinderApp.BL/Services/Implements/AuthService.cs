using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class AuthService(IJwtTokenHandler _tokenHandler,UserManager<User> _userManager,SignInManager<User> _signInManager,RoleManager<IdentityRole> _roleManager,IMapper _mapper) : IAuthService
    {
        public async Task<string> LoginAsync(LoginDto dto)
        {
            if (dto == null)
                throw new Exception("Invalid login request.");

            User? user = null;

            if (dto.UsernameOrEmail.Contains("@"))
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            else
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);

            if (user == null)
                throw new Exception("User not found. Please confirm your account.");

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    throw new Exception($"Your account is locked. Please wait until {user.LockoutEnd!.Value:yyyy-MMM-dd HH:mm:ss}.");
                }

                if (result.IsNotAllowed)
                {
                    throw new Exception("Username or password is incorrect.");
                }

                throw new Exception("Login failed.");
            }


            return _tokenHandler.CreateToken(user, 36);

                    }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists with this email.");
            }

            User user = _mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                throw new Exception("User creation failed.");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Viewer));
            if (!roleResult.Succeeded)
            {
                throw new Exception("Role assignment failed.");
            }

           
        }
    }
}
