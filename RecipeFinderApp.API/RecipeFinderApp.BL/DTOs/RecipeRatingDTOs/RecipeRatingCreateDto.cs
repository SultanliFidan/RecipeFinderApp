using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeRatingDTOs
{
    public class RecipeRatingCreateDto
    {
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public int RatingRate { get; set; }
    }
}
