﻿using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.Exceptioins.Common;
using RecipeFinderApp.BL.Extensions;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class RecipeService(IMapper _mapper, IGenericRepository<Recipe> _recipeRepository) : IRecipeService
    {
        public async Task CreateRecipe(RecipeCreateDto dto, string uploadPath)
        {
            Recipe recipe = _mapper.Map<Recipe>(dto);
            if (dto.File != null && dto.File.isValidType("image") && dto.File.isValidSize(400))
            {
                string fileName = await dto.File.UploadAsync(uploadPath);
                recipe.ImageUrl = Path.Combine("wwwroot","recipes",fileName);
            } 

            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.SaveAsync();
        }

        public async Task DeleteRecipe(int id)
        {
           
            await _recipeRepository.DeleteAndSaveAsync(id);
        }

        public async Task<IEnumerable<RecipeGetDto>> GetAllRecipe()
        {
            var recipes = await _recipeRepository.GetAllAsync(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                UserId = x.UserId,
                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()
            }, false);

            return recipes;

        }

        public async Task<IEnumerable<RecipeGetDto>> GetAllDeletedRecipe()
        {
            var recipes = await _recipeRepository.GetAllAsync(x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                UserId = x.UserId,
                Ingredients = x.RecipeIngredients.Select(ri => ri.Ingredient.Name).ToList()
            },
        isDeleted: true);

            return recipes;
        }

        public async Task<RecipeGetDto?> GetByIdRecipe(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id, x => new RecipeGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Instruction = x.Instruction,
                ImageUrl = x.ImageUrl,
                PreparationTime = x.PreparationTime,
                UserId = x.UserId,
                Ingredients = x.RecipeIngredients.Select(x => x.Ingredient.Name).ToList()
            }, false);

            return recipe;
        }

        public async Task RestoreRecipe(int id)
        {
            await _recipeRepository.ReverseSoftDeleteAsync(id);
            await _recipeRepository.SaveAsync();
        }

        public async Task SoftDeleteRecipe(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id, false);
            if (recipe == null) throw new NotFoundException<Recipe>();

            recipe.IsDeleted = true; 
            await _recipeRepository.SaveAsync();
        }

        public async Task UpdateRecipe(int id,RecipeUpdateDto dto, string uploadPath)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id, false);
            if (recipe == null) throw new NotFoundException<Recipe>();

            _mapper.Map(dto, recipe);

            if (dto.ImageUrl != null && dto.ImageUrl.isValidType("image") && dto.ImageUrl.isValidSize(400))
            {
                string fileName = await dto.ImageUrl.UploadAsync(uploadPath);
                recipe.ImageUrl = Path.Combine("wwwroot", "recipes", fileName);
            }

            await _recipeRepository.SaveAsync();
        }
    }
}
