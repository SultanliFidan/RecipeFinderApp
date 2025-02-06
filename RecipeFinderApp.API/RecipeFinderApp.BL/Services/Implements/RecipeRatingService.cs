using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class RecipeRatingService(IGenericRepository<RecipeRating> _ratingRepository) : IRecipeRatingService
    {
        public Task AddRating(int? recipeId, int rate = 1)
        {
            throw new NotImplementedException();
        }
    }
}
