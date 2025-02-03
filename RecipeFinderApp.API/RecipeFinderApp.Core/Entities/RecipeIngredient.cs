using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class RecipeIngredient : BaseEntity
    {
        
        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
        public string Quantity { get; set; }

    }
}
