using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IEmailService
    {
        Task SendEmailAsync(string reason, string email, string? forgotToken);


    }
}
