using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs
{
    public class UserFavoriteRecipeGetDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
