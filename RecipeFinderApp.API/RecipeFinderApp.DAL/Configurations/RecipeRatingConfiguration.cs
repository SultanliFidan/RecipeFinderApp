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
    public class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRating>
    {
        public void Configure(EntityTypeBuilder<RecipeRating> builder)
        {
            builder.HasOne(x => x.Recipe)
               .WithMany(c => c.RecipeRatings)
               .HasForeignKey(x => x.RecipeId); 
            builder.HasOne(x => x.User)
                .WithMany(c => c.RecipeRatings)
                .HasForeignKey(x => x.UserId); ;
        }
    }
}
