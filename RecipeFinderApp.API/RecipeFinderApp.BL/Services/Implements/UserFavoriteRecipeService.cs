using AutoMapper;
using RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class UserFavoriteRecipeService(IMapper _mapper, IGenericRepository<UserFavoriteRecipe> _favoriteRepository) : IUserFavoriteRecipeService
    {
        public async Task CreateUserFavoriteRecipe(UserFavoriteRecipeCreateDto dto)
        {
            UserFavoriteRecipe favorite = _mapper.Map<UserFavoriteRecipe>(dto);
            await _favoriteRepository.AddAsync(favorite);
            await _favoriteRepository.SaveAsync();
        }

        public async Task DeleteUserFavoriteRecipe(int id)
        {
            UserFavoriteRecipe? favorite = await _favoriteRepository.GetByIdAsync(id,false);
            if (favorite == null)
                throw new Exception("Favorite recipe not found");
            await _favoriteRepository.DeleteAndSaveAsync(id);
        }

       
    }
}
