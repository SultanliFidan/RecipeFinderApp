using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.UserDTOs
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
