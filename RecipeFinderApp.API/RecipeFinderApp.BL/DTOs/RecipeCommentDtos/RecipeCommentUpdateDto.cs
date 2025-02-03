using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.RecipeCommentDtos
{
    public class RecipeCommentUpdateDto
    {
        public int Id { get; set; }   
        public string Comment { get; set; }
    }
}
