using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.Services.Abstractions;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController(IRecipeService _recipeService, IWebHostEnvironment _env) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateDto dto)
        {
            string destination = _env.WebRootPath;
            await _recipeService.CreateRecipe(dto, destination);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllRecipe();
            return Ok(recipes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var recipe = await _recipeService.GetByIdRecipe(id);
            if (recipe == null) return NotFound("Recipe not found");
            return Ok(recipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,RecipeUpdateDto dto)
        {
            string destination = _env.WebRootPath;
            await _recipeService.UpdateRecipe(id, dto, destination);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _recipeService.DeleteRecipe(id);
            return Ok("Recipe deleted successfully");
        }

        [HttpPatch("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _recipeService.SoftDeleteRecipe(id);
            return Ok("Recipe soft deleted successfully" );
        }

        [HttpPatch("restore/{id}")]
        public async Task<IActionResult> Restore(int id)
        {
            await _recipeService.RestoreRecipe(id);
            return Ok("Recipe restored successfully");
        }
    }
}
