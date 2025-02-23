using RecipeFinderApp.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IPasswordService
    {
        Task ForgotPasswordAsync(string email);
        Task ResetPasswordAsync(ResetPasswordDto dto);
        Task ChangePasswordAsync(ChangePasswordDto dto);
    }
}
