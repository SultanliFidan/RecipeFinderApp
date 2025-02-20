using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.UserFavoriteRecipeDTOs
{
    public class UserFavoriteRecipeCreateDto
    {
        //public string UserId { get; set; }
        public int RecipeId { get; set; }
    }
}
