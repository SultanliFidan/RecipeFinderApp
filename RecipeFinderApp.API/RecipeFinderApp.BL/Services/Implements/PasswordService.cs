using Microsoft.AspNetCore.Identity;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class PasswordService(UserManager<User> _userManager, IEmailService _emailService) : IPasswordService
    {
        public async Task ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) throw new Exception("Unknown user.");

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _emailService.SendEmailAsync("forgotPassword", email, token);
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) throw new Exception("Unknown user.");

            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Unsuccessful reset password.");
            }
        }

        public async Task ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) throw new Exception("Unknown user.");

            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
            if (!result.Succeeded)
            {
                throw new Exception("Unsuccessful change password.");
            }
        }
    }


}
