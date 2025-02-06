using Microsoft.Extensions.DependencyInjection;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeCommentRepository, RecipeCommentRepository>();
            services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
            services.AddScoped<IRecipeRatingRepository, RecipeRatingRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUserFavoriteRecipeRepository, UserFavoriteRecipeRepository>();
           
            return services;
        }
    }
}
