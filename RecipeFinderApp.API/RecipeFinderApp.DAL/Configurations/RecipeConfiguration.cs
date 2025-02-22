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
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property( x => x.Instruction)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(x => x.ImageUrl)
               .IsRequired()
               .HasMaxLength(255);
            builder.HasMany(x => x.RecipeIngredients)
                .WithOne(r => r.Recipe)
                .HasForeignKey(i => i.RecipeId);
            builder.HasMany(x => x.RecipeComments)
                .WithOne(r => r.Recipe)
                .HasForeignKey(i => i.RecipeId);
            builder.HasMany(x => x.RecipeRatings)
                .WithOne(r => r.Recipe)
                .HasForeignKey(i => i.RecipeId);
            builder.HasMany(x => x.UserFavoriteRecipes)
               .WithOne(r => r.Recipe)
               .HasForeignKey(i => i.RecipeId);

        }
    }
}
