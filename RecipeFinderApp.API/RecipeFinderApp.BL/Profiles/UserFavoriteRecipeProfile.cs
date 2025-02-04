using AutoMapper;
using RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class UserFavoriteRecipeProfile : Profile
    {
        public UserFavoriteRecipeProfile()
        {
            CreateMap<UserFavoriteRecipeCreateDto, UserFavoriteRecipe>();
            CreateMap<UserFavoriteRecipeUpdateDto, UserFavoriteRecipe>();
            CreateMap<UserFavoriteRecipe, UserFavoriteRecipeGetDto>();
        }
    }
}
