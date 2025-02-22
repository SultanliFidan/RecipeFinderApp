using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.Services.Abstractions;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IEmailService _service) : ControllerBase
    {
        
        [HttpPost("[action]")]
        public async Task<IActionResult> SendMail()
        {
            await _service.SendEmail();
            return Content("Email sended");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Verify(string token)
        {
            await _service.Verify(token);
            return Content("Email confirmed");
        }
    }
}
