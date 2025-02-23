using RecipeFinderApp.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.ExternalServices.Abstractions
{
    public interface ICurrentUser
    {
        string GetId();
        string GetUserName();
        string GetEmail();
        string GetName();
        int GetRole();
        Task<UserGetDto> GetUserAsync();
    }
}
