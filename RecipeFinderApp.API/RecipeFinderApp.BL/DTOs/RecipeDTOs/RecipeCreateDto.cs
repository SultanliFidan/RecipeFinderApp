using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeDTOs
{
    public class RecipeCreateDto
    {
        public string Title { get; set; }
        public string Instruction { get; set; }
        public IFormFile File { get; set; }
        public int PreparationTime { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}
