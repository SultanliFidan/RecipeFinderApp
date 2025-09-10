using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs;
using RecipeFinderApp.BL.Exceptioins.Common;
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
    public class RecipeIngredientService(IMapper _mapper, IGenericRepository<RecipeIngredient> _recipeIngredientRepository) : IRecipeIngredientService
    {
        public async Task AddRecipeIngredien(RecipeIngredientCreateDto dto)
        {
            RecipeIngredient recipeIngredient = _mapper.Map<RecipeIngredient>(dto);
            await _recipeIngredientRepository.AddAsync(recipeIngredient);
            await _recipeIngredientRepository.SaveAsync();
        }

        public async Task DeleteRecipeIngredien(int id)
        {
            RecipeIngredient? recipeIngredient = await _recipeIngredientRepository.GetByIdAsync(id, false);
            if (recipeIngredient == null)
                throw new NotFoundException<RecipeIngredient>();
            await _recipeIngredientRepository.DeleteAndSaveAsync(id);
        }

        public async Task<IEnumerable<RecipeIngredientGetDto>> GetAllRecipeIngredient()
        {
            var recipeIngredients = await _recipeIngredientRepository.GetAllAsync(x => new RecipeIngredientGetDto
            {
                Id = x.Id,
                Quantity = x.Quantity,
                RecipeId = x.RecipeId,
                IngredientId = x.IngredientId,
                Ingredient = x.Ingredient.Name,
                Recipe = new RecipeBasicDto
                {
                    Id = x.Recipe.Id,
                    Title = x.Recipe.Title
                },
            },  true, false,false);

            return recipeIngredients;
        }

        public async Task<RecipeIngredientGetDto?> GetByIdRecipeIngredient(int id)
        {
            var recipeIngredient = await _recipeIngredientRepository.GetByIdAsync(id, x => new RecipeIngredientGetDto
            {
                Id = x.Id,
                Quantity = x.Quantity,
                RecipeId = x.RecipeId,
                IngredientId = x.IngredientId,
                Ingredient = x.Ingredient.Name,
                Recipe = new RecipeBasicDto
                {
                    Id = x.Recipe.Id,
                    Title = x.Recipe.Title
                },
            },  false);

            return recipeIngredient;
        }

        public async Task UpdateRecipeIngredien(int id, RecipeIngredientUpdateDto dto)
        {
            RecipeIngredient? recipeIngredient = await _recipeIngredientRepository.GetByIdAsync(id,false);
            if (recipeIngredient == null)
                throw new NotFoundException<RecipeIngredient>();
            _mapper.Map(dto, recipeIngredient);
            await _recipeIngredientRepository.SaveAsync();
        }
    }
}
