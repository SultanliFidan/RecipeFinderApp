using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeDTOs
{
    public class RecipeGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instruction { get; set; }
        public string ImageUrl { get; set; } 
        public DateTime PreparationTime { get; set; }
        public string UserId { get; set; }
        public ICollection<RecipeComment>? RecipeComments { get; set; }
        public ICollection<RecipeRating>? RecipeRatings { get; set; }
        public List<string> Ingredients { get; set; } 
    }
}
