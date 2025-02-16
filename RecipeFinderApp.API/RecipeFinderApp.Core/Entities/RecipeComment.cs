using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class RecipeComment : BaseEntity
    {
        public string Comment { get; set; }
        public int? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public int? ParentId { get; set; }
        public RecipeComment? Parent { get; set; }
        public IEnumerable<RecipeComment>? Children { get; set; }
    }
}
