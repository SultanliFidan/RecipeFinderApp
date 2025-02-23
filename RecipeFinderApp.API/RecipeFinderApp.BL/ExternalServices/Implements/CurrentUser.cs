using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.BL.Exceptioins.Common;
using RecipeFinderApp.BL.Exceptions.UserException;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.ExternalServices.Implements
{
    public class CurrentUser(IHttpContextAccessor _httpContext,
    UserManager<User> _userManager,
     IMapper _mapper) : ICurrentUser
    {
        ClaimsPrincipal? User = _httpContext.HttpContext?.User;
        public string GetEmail()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.Email)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return value;
        }

        public string GetName()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.Name)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return value;
        }

        public string GetId()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return value;
        }

        public int GetRole()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.Role)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return Convert.ToInt32(value);
        }

        public async Task<UserGetDto> GetUserAsync()
        {
            string name = GetName();
            var user = await _userManager.FindByNameAsync(name);
            return _mapper.Map<UserGetDto>(user);
        }

        public string GetUserName()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.Name)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return value;
        }
    }
}
