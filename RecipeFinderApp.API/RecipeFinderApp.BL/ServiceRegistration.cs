using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeFinderApp.BL.ExternalServices.Abstractions;
using RecipeFinderApp.BL.ExternalServices.Implements;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.BL.Services.Implements;
using System.Net.Mail;

namespace RecipeFinderApp.BL
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();
            services.AddScoped<IRecipeCommentService, RecipeCommentService>();
            services.AddScoped<IRecipeRatingService, RecipeRatingService>();
            services.AddScoped<IUserFavoriteRecipeService, UserFavoriteRecipeService>();
            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IVerifyService, VerifyService>();

            return services;
        }


        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration));
            return services;
        }

    }
}
