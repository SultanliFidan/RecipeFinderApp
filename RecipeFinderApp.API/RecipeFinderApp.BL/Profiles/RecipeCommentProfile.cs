using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeCommentDtos;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class RecipeCommentProfile : Profile
    {
        public RecipeCommentProfile()
        {
            CreateMap<RecipeCommentCreateDto, RecipeComment>();
            CreateMap<RecipeCommentUpdateDto, RecipeComment>();
            CreateMap<RecipeComment, RecipeCommentGetDto>();
        }
    }
}
