using AutoMapper;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<User, UserGetDto>();
        }
    }
}
