using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeIngredientDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class RecipeIngredientProfile : Profile
    {
        public RecipeIngredientProfile()
        {
            CreateMap<RecipeIngredientCreateDto, RecipeIngredient>();
            CreateMap<RecipeIngredientUpdateDto, RecipeIngredient>();
            CreateMap<RecipeIngredient, RecipeIngredientGetDto>();
        }
    }
}
