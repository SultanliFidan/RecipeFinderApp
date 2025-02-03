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
        public string Comment { get; set; }
        public string UserFullname { get; set; } 
        public string? UserProfileImage { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
