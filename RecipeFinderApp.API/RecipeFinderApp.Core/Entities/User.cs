using Microsoft.AspNetCore.Identity;
using RecipeFinderApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Roles Role { get; set; } 
        public ICollection<Recipe>? Recipes { get; set; }
        public ICollection<RecipeComment>? RecipeComments { get; set; }
        public ICollection<RecipeRating>? RecipeRatings { get; set; }
        public ICollection<UserFavoriteRecipe>? UserFavoriteRecipes { get; set; }
    }
}
