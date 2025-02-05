using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IRecipeCommentService
    {
        Task AddComment(RecipeCommentCreateDto dto);
    }
}
