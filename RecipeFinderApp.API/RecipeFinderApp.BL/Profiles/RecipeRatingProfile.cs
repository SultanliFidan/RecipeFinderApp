using AutoMapper;
using RecipeFinderApp.BL.DTOs.RecipeRatingDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class RecipeRatingProfile : Profile
    {
        public RecipeRatingProfile()
        {
            CreateMap<RecipeRatingCreateDto, RecipeRating>();
            CreateMap<RecipeRatingUpdateDto, RecipeRating>();
            CreateMap<RecipeRating, RecipeRatingGetDto>();
        }
    }
}
