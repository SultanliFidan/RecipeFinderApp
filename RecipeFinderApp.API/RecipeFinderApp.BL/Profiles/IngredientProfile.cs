using AutoMapper;
using RecipeFinderApp.BL.DTOs.IngredientDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientUpdateDto, Ingredient>();
            CreateMap<Ingredient, IngredientGetDto>();
        }
    }
}
