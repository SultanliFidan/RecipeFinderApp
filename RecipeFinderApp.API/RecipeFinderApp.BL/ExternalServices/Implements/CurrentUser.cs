using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        //public string GetFullname()
        //{
        //    var value = User.FindFirst(x => x.Type == ClaimTypes.Fullname)?.Value;
        //    if (value is null)
        //        throw new Exception("Not Found");
        //    return value;
        //}

        public int GetId()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return Convert.ToInt32(value);
        }

        public int GetRole()
        {
            var value = User.FindFirst(x => x.Type == ClaimTypes.Role)?.Value;
            if (value is null)
                throw new UserNotFoundException();
            return Convert.ToInt32(value);
        }

        //public async Task<UserGetDto> GetUserAsync()
        //{
        //    int userId = GetId();
        //    var user = await _repo.GetByIdAsync(userId);
        //    return _mapper.Map<UserGetDto>(user);
        //}

        //public string GetUserName()
        //{
        //    var value = User.FindFirst(x => x.Type == ClaimTypes.Username)?.Value;
        //    if (value is null)
        //        throw new Exception("Not Found");
        //    return value;
        //}
    }
}
