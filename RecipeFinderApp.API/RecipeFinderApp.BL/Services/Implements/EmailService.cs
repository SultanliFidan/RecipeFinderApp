using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class EmailService : IEmailService
    {
        readonly UserManager<User> _userManager;
        readonly SmtpClient _client;
        readonly IMemoryCache _cache;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly MailAddress _from;
        readonly RecipeFinderDbContext _context;

        public EmailService(IOptions<EmailOptions> options,RecipeFinderDbContext context,UserManager<User> userManager ,SmtpClient client, IMemoryCache cache, IHttpContextAccessor httpContextAccessor)
        {
            var opt = options.Value;
            _client = new(opt.Host, opt.Port);
            _client.Credentials = new NetworkCredential(opt.Sender, opt.Password);
            _client.EnableSsl = true;
            _from = new MailAddress(opt.Sender, "RecipeFinder");
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }
        public async Task SendEmail()
        {
            string? email =  _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimType.Email).Value;
            string? name = _httpContextAccessor?.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimType.FullName).Value;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
                throw new Exception("User is not authenticated");
            var token = Guid.NewGuid().ToString();
            _cache.Set(token, name, TimeSpan.FromMinutes(30));
            MailAddress to = new MailAddress(email);
            MailMessage message = new(_from,to);
            message.Subject = "Confirm your email address";
            message.Body = token;
            await _client.SendMailAsync(message);
        }

        public async Task Verify(string userToken)
        {
            string? name = _httpContextAccessor?.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimType.FullName).Value;
            var cacheToken = _cache.Get<string>(name);
            if (string.IsNullOrEmpty(userToken) || string.IsNullOrEmpty(cacheToken) || string.IsNullOrEmpty(name))
                throw new Exception("User is not authenticated or token is missing");
            if (cacheToken != userToken)
                throw new Exception("User is not authenticated or token is missing");

            User? user = await _userManager.FindByNameAsync(name);
            user!.Role = Roles.Publisher;
            await _context.SaveChangesAsync();
        }
    }
}
