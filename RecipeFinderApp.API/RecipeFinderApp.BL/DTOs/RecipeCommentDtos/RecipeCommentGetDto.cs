using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeCommentDtos
{
    public class RecipeCommentGetDto
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Comment { get; set; }
        public IEnumerable<RecipeCommentGetDto> Children { get; set; }

    }
}
