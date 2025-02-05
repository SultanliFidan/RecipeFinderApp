using RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IRecipeIngredientService
    {
        Task AddRecipeIngredien(RecipeIngredientCreateDto dto);
        Task UpdateRecipeIngredien(int id,RecipeIngredientUpdateDto dto);
        Task DeleteRecipeIngredien(int id);
        Task<IEnumerable<RecipeIngredientGetDto>> GetAllRecipeIngredient();
        Task<RecipeIngredientGetDto?> GetByIdRecipeIngredient(int id);
    }
}
