using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL.Configurations
{
    public class RecipeCommentConfiguration : IEntityTypeConfiguration<RecipeComment>
    {
        public void Configure(EntityTypeBuilder<RecipeComment> builder)
        {
            builder.Property(x => x.Comment)
                .HasMaxLength(128);
            builder.HasOne(x => x.Recipe)
                .WithMany(c => c.RecipeComments)
                .HasForeignKey(i => i.RecipeId);
            builder.HasOne(x => x.User)
                .WithMany(c => c.RecipeComments)
                .HasForeignKey(i => i.UserId);

        }
    }
}
