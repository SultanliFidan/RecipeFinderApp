using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeCreateDto, Recipe>();
            CreateMap<RecipeUpdateDto, Recipe>();
            CreateMap<Recipe, RecipeGetDto>();
        }
    }
}
