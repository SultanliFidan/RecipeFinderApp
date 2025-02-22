using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }
        //public string Comment { get; set; }
        public string Instruction { get; set; }
        public string ImageUrl { get; set; }
        public int PreparationTime { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public ICollection<RecipeComment>? RecipeComments { get; set; }
        public ICollection<RecipeRating>? RecipeRatings { get; set; }
        public ICollection<UserFavoriteRecipe>? UserFavoriteRecipes { get; set; }
    }
}
