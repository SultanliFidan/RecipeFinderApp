using AutoMapper;
using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.BL.Exceptioins.Common;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class RecipeCommentService(IMapper _mapper, IGenericRepository<RecipeComment> _comment, IHttpContextAccessor _httpContext) : IRecipeCommentService
    {
        public async Task AddComment(RecipeCommentCreateDto dto)
        {
            RecipeComment? parent = null;
            if (dto.ParentId.HasValue)
            {
                parent = await _comment.GetByIdAsync(dto.ParentId.Value);
                if (parent is null)
                    throw new NotFoundException<RecipeComment>();
            }
            var entity = _mapper.Map<RecipeComment>(dto);
            entity.UserId = _httpContext.HttpContext?.User.FindFirst(x => x.Type == ClaimType.Id)?.Value;
            entity.RecipeId = parent?.RecipeId ?? dto.RecipeId;
            await _comment.AddAsync(entity);
            await _comment.SaveAsync();
        }
    }
}
