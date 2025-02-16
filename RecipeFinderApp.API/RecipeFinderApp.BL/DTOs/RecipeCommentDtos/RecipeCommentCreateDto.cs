using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeCommentDtos
{
    public class RecipeCommentCreateDto
    {
        public int? ParentId { get; set; } 
        public int RecipeId { get; set; }  
        public string Comment { get; set; }
    }
}
