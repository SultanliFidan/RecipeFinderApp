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
    public class RecipeRepository : GenericRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(RecipeFinderDbContext _context) : base(_context)
        {
        }
    }
}
