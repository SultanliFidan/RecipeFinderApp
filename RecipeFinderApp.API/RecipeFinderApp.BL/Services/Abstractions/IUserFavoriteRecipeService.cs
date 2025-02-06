using RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IUserFavoriteRecipeService
    {
        Task CreateUserFavoriteRecipe(UserFavoriteRecipeCreateDto dto);
        Task DeleteUserFavoriteRecipe(int id);
    }
}
