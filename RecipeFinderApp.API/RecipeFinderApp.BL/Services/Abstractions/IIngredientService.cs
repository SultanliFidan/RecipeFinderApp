using RecipeFinderApp.BL.DTOs.IngredientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IIngredientService
    {
        Task CreateIngredient(IngredientCreateDto dto);
        Task DeleteIngredient(int id);
        Task UpdateIngredient(int id,IngredientUpdateDto dto);
        Task<IngredientGetDto?> GetByIdIngredient(int id);
        Task<IEnumerable<IngredientGetDto>> GetAll();
    }
}
