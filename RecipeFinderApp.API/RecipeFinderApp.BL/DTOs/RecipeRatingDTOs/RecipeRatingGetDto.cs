using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeRatingDTOs
{
    public class RecipeRatingGetDto
    {
        public int Id { get; set; }
        public int RatingRate { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        //public string UserFullname { get; set; }
        //public string? UserProfileImage { get; set; }
        //public DateTime CreatedAt { get; set; }
    }
}
