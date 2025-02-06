using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.BL.Services.Implements;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteRecipeController(IUserFavoriteRecipeService _userFavoriteRecipeService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(UserFavoriteRecipeCreateDto dto)
        {
            await _userFavoriteRecipeService.CreateUserFavoriteRecipe(dto);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userFavoriteRecipeService.DeleteUserFavoriteRecipe(id);
            return Ok();
        }
    }
}

