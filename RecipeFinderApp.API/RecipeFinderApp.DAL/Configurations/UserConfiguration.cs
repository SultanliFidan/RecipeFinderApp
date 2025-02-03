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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Fullname)
               .IsRequired()
               .HasMaxLength(128);
            builder.Property(x => x.ProfileImageUrl)
               .HasMaxLength(255);
            builder.HasMany(x => x.Recipes)
               .WithOne(u => u.User)
               .HasForeignKey(i => i.UserId);
            builder.HasMany(x => x.RecipeComments)
               .WithOne(u => u.User)
               .HasForeignKey(i => i.UserId);
            builder.HasMany(x => x.RecipeRatings)
                .WithOne(u => u.User)
                .HasForeignKey(i => i.UserId);
            builder.HasMany(x => x.UserFavoriteRecipes)
               .WithOne(u => u.User)
               .HasForeignKey(i => i.UserId);
        }
    }
}
