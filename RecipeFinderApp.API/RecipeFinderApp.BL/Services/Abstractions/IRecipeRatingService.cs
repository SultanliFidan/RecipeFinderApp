using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IRecipeRatingService
    {
        Task AddRating(int? recipeId, int rate = 1);
    }
}
