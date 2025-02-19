using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.Attributes;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.Helpers;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Enums;
using System.Runtime.InteropServices;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController(IRecipeService _recipeService, IWebHostEnvironment _env) : ControllerBase
    {
        
        [HttpPost]
        //[Auth(Roles.Publisher)]
        [Authorize(Roles = RoleConstants.Recipe)]
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
        [Auth(Roles.Publisher)]
        public async Task<IActionResult> Update(int id,RecipeUpdateDto dto)
        {
            string destination = _env.WebRootPath;
            await _recipeService.UpdateRecipe(id, dto, destination);
            return Ok();
        }

        [HttpDelete("{id}")]
        //[Auth(Roles.Publisher)]
        public async Task<IActionResult> Delete(int id)
        {
            await _recipeService.DeleteRecipe(id);
            return Ok("Recipe deleted successfully");
        }

        [HttpDelete("soft-delete/{id}")]
        //[Auth(Roles.Publisher)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _recipeService.SoftDeleteRecipe(id);
            return Ok("Recipe soft deleted successfully" );
        }

        [HttpPut("restore/{id}")]
        //[Auth(Roles.Publisher)]
        public async Task<IActionResult> Restore(int id)
        {
            await _recipeService.RestoreRecipe(id);
            return Ok("Recipe restored successfully");
        }

        [HttpPost("[action]")]
        [Auth(Roles.Publisher | Roles.Viewer)]
        
        public async Task<IActionResult> Comment(RecipeCommentCreateDto dto)
        {
            await _recipeService.RecipeComment(dto);
            return Ok();
        }

        [HttpPost("[action]")]
        [Auth(Roles.Publisher | Roles.Viewer)]
        public async Task<IActionResult> Rate(int? recipeId, int rate = 1)
        {
            await _recipeService.Rate(recipeId,rate);
            return Ok();
        }
    }
}
