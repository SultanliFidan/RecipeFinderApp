using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class RecipeCommentService(IMapper _mapper, IGenericRepository<RecipeComment> _recipeCommentRepository) : IRecipeCommentService
    {
        public Task AddComment(RecipeCommentCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
