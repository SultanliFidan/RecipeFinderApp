using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.ReportDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using System.Security.Claims;

namespace RecipeFinderApp.API.Controllers
{
    [Authorize]
    [Route("api/reports")]
    [ApiController]
    public class ReportsController(IReportService _service) : ControllerBase
    {
      

        // ✅ Yeni report əlavə edir
        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] ReportDto reportDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();

            await _service.AddReportAsync(reportDto, userId);
            return Ok(new { message = "Report successfully submitted." });
        }

        // ✅ İstifadəçinin neçə dəfə report olunduğunu qaytarır
        [HttpGet("user/{reportedUserId}")]
        public async Task<IActionResult> GetReportCount(string reportedUserId)
        {
            var count = await _service.GetReportCountForUserAsync(reportedUserId);
            return Ok(new { reportCount = count });
        }
    }

}
