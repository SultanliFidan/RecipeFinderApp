using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs;
using RecipeFinderApp.BL.Helpers;
using RecipeFinderApp.BL.Services.Abstractions;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleConstants.Recipe)]
    public class RecipeIngredientController(IRecipeIngredientService _recipeIngredientService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(RecipeIngredientCreateDto dto)
        {
            await _recipeIngredientService.AddRecipeIngredien(dto);
            return Created();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipeIngredients = await _recipeIngredientService.GetAllRecipeIngredient();
            return Ok(recipeIngredients);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipeIngredient = await _recipeIngredientService.GetByIdRecipeIngredient(id);
            if (recipeIngredient == null) return NotFound("Recipe Ingredient not found");
            return Ok(recipeIngredient);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RecipeIngredientUpdateDto dto)
        {
            await _recipeIngredientService.UpdateRecipeIngredien(id, dto);
            return NoContent(); 
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _recipeIngredientService.DeleteRecipeIngredien(id);
            return Ok("Recipe Ingredient deleted successfully");
        }
    }
}
