using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class RecipeRating : BaseEntity
    {
        
        public int RatingRate { get; set; }
        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
