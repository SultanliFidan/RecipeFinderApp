using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeRatingDTOs
{
    public class RatingGetDto
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public string? UserId { get; set; }
        public int RatingRate { get; set; }
        public UserGetDto User { get; set; }
        public RecipeBasicDto Recipe { get; set; }
}
}
