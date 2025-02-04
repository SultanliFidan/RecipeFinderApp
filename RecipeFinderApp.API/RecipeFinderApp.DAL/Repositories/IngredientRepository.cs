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
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeFinderDbContext _context) : base(_context)
        {
        }
    }
}
