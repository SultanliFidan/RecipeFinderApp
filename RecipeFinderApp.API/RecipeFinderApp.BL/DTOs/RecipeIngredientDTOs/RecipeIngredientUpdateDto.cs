using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs
{
    public class RecipeIngredientUpdateDto
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
    }
}
