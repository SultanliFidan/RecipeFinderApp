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
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasOne(x => x.Ingredient)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(i => i.IngredientId);
            builder.HasOne(x => x.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(i => i.RecipeId);

        }
    }
}
