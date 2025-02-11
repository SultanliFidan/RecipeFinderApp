using AutoMapper;
using RecipeFinderApp.BL.DTOs.UserDTOs;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<User, UserGetDto>();
            CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.ProfileImageUrl, opt => opt.MapFrom(src => src.Image))
            .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false)); 
        }
    }
}
