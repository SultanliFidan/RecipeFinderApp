using AutoMapper;
using RecipeFinderApp.BL.DTOs.IngredientDTOs;
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
    public class IngredientService(IMapper _mapper, IGenericRepository<Ingredient> _ingredientRepository) : IIngredientService
    {
        public async Task CreateIngredient(IngredientCreateDto dto)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(dto);
            await _ingredientRepository.AddAsync(ingredient);
            await _ingredientRepository.SaveAsync();
        }

        public async Task DeleteIngredient(int id)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id, false);
            if (ingredient == null)
                throw new NotFoundException<Ingredient>();
            await _ingredientRepository.DeleteAndSaveAsync(id);
        }

        public async Task<IEnumerable<IngredientGetDto>> GetAll()
        {
            var ingredients = await _ingredientRepository.GetAllAsync(x => new IngredientGetDto
            {
                Id = x.Id,
                Name = x.Name,
                RecipeIngredients = x.RecipeIngredients.Select(x => new RecipeIngredientGetDto
                {
                    IngredientId = x.IngredientId,
                    Ingredient = x.Ingredient.Name,
                    RecipeId = x.RecipeId,
                    Recipe = new RecipeBasicDto
                    {
                        Id = x.Recipe.Id,
                        Title = x.Recipe.Title
                    },
                    Quantity = x.Quantity,
                    Id = x.Id
                }).ToList()

            }, false, true,true); 

            return ingredients;
        }

        public async Task<IngredientGetDto?> GetByIdIngredient(int id)
        {
            var ingredient = await _ingredientRepository.GetByIdAsync(id, x => new IngredientGetDto
            {
                Id = x.Id,
                Name = x.Name,
                RecipeIngredients = x.RecipeIngredients.Select(x => new RecipeIngredientGetDto
                {
                    IngredientId = x.IngredientId,
                    Ingredient = x.Ingredient.Name,
                    RecipeId = x.RecipeId,
                    Recipe = new RecipeBasicDto
                    {
                        Id = x.Recipe.Id,
                        Title = x.Recipe.Title
                    },
                    Quantity = x.Quantity,
                    Id = x.Id
                }).ToList()
            }, false);

            return ingredient;
        }

        public async Task UpdateIngredient(int id, IngredientUpdateDto dto)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id,false);
            if (ingredient == null)
                throw new NotFoundException<Ingredient>();
            _mapper.Map(dto, ingredient);
            await _ingredientRepository.SaveAsync();
        }
    }
}
