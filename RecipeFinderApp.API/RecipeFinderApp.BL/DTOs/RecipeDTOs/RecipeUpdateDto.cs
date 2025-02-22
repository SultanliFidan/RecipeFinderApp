using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeDTOs
{
    public class RecipeUpdateDto
    {
        
        public string Title { get; set; }
        public string Instruction { get; set; }
        public IFormFile? ImageUrl { get; set; } 
        public int? PreparationTime { get; set; } 
        public List<int>? IngredientIds { get; set; }
    }
}
