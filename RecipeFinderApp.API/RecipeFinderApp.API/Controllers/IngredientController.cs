﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinderApp.BL.DTOs.IngredientDTOs;
using RecipeFinderApp.BL.Helpers;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.BL.Services.Implements;

namespace RecipeFinderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleConstants.Recipe)]

    public class IngredientController(IIngredientService _ingredientService) : ControllerBase
    {
        [HttpPost]
        
        public async Task<IActionResult> Create(IngredientCreateDto dto)
        {
            await _ingredientService.CreateIngredient(dto);
            return Created();
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var ingredients = await _ingredientService.GetAll();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ingredient = await _ingredientService.GetByIdIngredient(id);
            if (ingredient == null) return NotFound("Ingredient not found");
            return Ok(ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IngredientUpdateDto dto)
        {
            await _ingredientService.UpdateIngredient(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           
            await _ingredientService.DeleteIngredient(id);
            return Ok();
        }
    }
}
