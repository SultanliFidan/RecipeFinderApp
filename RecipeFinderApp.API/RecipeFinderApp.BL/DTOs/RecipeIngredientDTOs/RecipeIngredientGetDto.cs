using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs
{
    public class RecipeIngredientGetDto
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string Ingredient { get; set; }
        public RecipeBasicDto Recipe { get; set; }
       
    }
}
