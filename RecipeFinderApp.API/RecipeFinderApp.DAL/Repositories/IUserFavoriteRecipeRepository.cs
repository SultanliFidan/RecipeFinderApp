using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL.Repositories
{
    public class UserFavoriteRecipeRepository : GenericRepository<UserFavoriteRecipe>, IUserFavoriteRecipeRepository
    {
        public UserFavoriteRecipeRepository(RecipeFinderDbContext _context) : base(_context)
        {
        }
    }
}
