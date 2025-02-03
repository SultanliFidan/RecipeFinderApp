using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL.Configurations
{
    public class UserFavoriteRecipeConfiguration : IEntityTypeConfiguration<UserFavoriteRecipe>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteRecipe> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(u => u.UserFavoriteRecipes)
                .HasForeignKey(i => i.UserId);
            builder.HasOne(x => x.Recipe)
                .WithMany(u => u.UserFavoriteRecipes)
                .HasForeignKey(i => i.RecipeId);
        }
    }
}
