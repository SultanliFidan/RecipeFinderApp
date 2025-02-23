using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Server;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{

    public class EmailService : IEmailService
    {

        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly MailAddress _from;
        private readonly RecipeFinderDbContext _context;
        private readonly EmailOptions _emailOptions;
        private readonly UserManager<User> _userManager;

        public EmailService(IOptions<EmailOptions> options, RecipeFinderDbContext context,
                            UserManager<User> userManager, IMemoryCache cache,
                            IHttpContextAccessor httpContextAccessor)
        {
            _emailOptions = options.Value;
            _from = new MailAddress(_emailOptions.Sender, "RecipeFinder");
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;

            _context = context;
        }


        public async Task SendEmailAsync(string reason, string? email, string? forgotToken)
        {
            string token = null;
            if (reason == "confirmation")
            {
                token = Guid.NewGuid().ToString();
                email = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                string? name = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
                    throw new UnauthorizedAccessException("User is not authenticated");

                _cache.Set(name, token, TimeSpan.FromMinutes(30));

            }
            else if (reason == "forgotPassword")
            {
                _cache.Set(email, forgotToken, TimeSpan.FromMinutes(30));
            }


            using (SmtpClient client = new SmtpClient(_emailOptions.Host, _emailOptions.Port))
            {
                client.Credentials = new NetworkCredential(_emailOptions.Sender, _emailOptions.Password);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                MailAddress to = new MailAddress(email);
                MailMessage message = new(_from, to);
                message.Subject = "Reset Password";
                if (reason == "confirmation")
                    message.Body = $"Hi, confirmation token: {token}";
                else if (reason == "forgotPassword")
                    message.Body = $"Hi, forgot token: {forgotToken}";


                await client.SendMailAsync(message);
            }
        }

    }
}