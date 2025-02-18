﻿using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IRecipeService
    {
        Task CreateRecipe(RecipeCreateDto dto, string destination);
        Task UpdateRecipe(int id,RecipeUpdateDto dto, string uploadPath);
        Task DeleteRecipe(int id); 
        Task SoftDeleteRecipe(int id);  
        Task RestoreRecipe(int id);  
        Task<RecipeGetDto?> GetByIdRecipe(int id);
        Task RecipeComment(RecipeCommentCreateDto dto);
        Task Rate(int? recipeId, int rate = 1);
        Task<IEnumerable<RecipeGetDto>> GetAllRecipe();  // Aktiv reseptlər
        Task<IEnumerable<RecipeGetDto>> GetAllDeletedRecipe();  // Silinmiş reseptlər
    }
}
