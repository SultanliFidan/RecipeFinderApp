using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.BL.Services.Implements;
using RecipeFinderApp.Core.Entities;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IEmailService _service,UserManager<User> _userManager) : ControllerBase
    {
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> SendMail()
        {
            await _service.SendEmailAsync("confirmation", null, null);
            return Content("Email sent");
        }





    }
}
