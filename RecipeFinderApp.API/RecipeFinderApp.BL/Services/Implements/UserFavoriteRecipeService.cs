using AutoMapper;
using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs;
using RecipeFinderApp.BL.Exceptioins.Common;
using RecipeFinderApp.BL.Exceptioins.UserException;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class UserFavoriteRecipeService(ICurrentUser _currentUser,IHttpContextAccessor _httpContext,IMapper _mapper, IGenericRepository<UserFavoriteRecipe> _favoriteRepository) : IUserFavoriteRecipeService
    {
        public async Task CreateUserFavoriteRecipe(UserFavoriteRecipeCreateDto dto)
        {
            string? userId = _currentUser.GetId();

            if (string.IsNullOrEmpty(userId))
                throw new AuthorizationException("User is not authenticated!");
            UserFavoriteRecipe favorite = _mapper.Map<UserFavoriteRecipe>(dto);
            favorite.UserId = userId;
            await _favoriteRepository.AddAsync(favorite);
            await _favoriteRepository.SaveAsync();
        }

        public async Task DeleteUserFavoriteRecipe(int id)
        {
            UserFavoriteRecipe? favorite = await _favoriteRepository.GetByIdAsync(id,false);
            if (favorite == null)
                throw new NotFoundException<UserFavoriteRecipe>();
            await _favoriteRepository.DeleteAndSaveAsync(id);
        }

       
    }
}
