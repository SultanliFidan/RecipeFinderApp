﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using RecipeFinderApp.BL.DTOs.Options;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Enums;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class VerifyService : IVerifyService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        private readonly RecipeFinderDbContext _context;
        
        public VerifyService(IOptions<EmailOptions> options, RecipeFinderDbContext context,
                            UserManager<User> userManager, IMemoryCache cache,
                            IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }
        public async Task Verify(string userToken)
        {
            string? name = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
            var cacheToken = _cache.Get<string>(name);
            if (string.IsNullOrEmpty(userToken) || string.IsNullOrEmpty(cacheToken) || string.IsNullOrEmpty(name))
                throw new Exception("User is not authenticated or token is missing");

            if (cacheToken != userToken)
                throw new Exception("User is not authenticated or token is missing");

            User? user = await _userManager.FindByNameAsync(name);
            string role = nameof(Roles.Publisher);
            var currentRoles = await _userManager.GetRolesAsync(user);


            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new Exception("islemir");
            }
            await _context.SaveChangesAsync();
        }
    }
}
