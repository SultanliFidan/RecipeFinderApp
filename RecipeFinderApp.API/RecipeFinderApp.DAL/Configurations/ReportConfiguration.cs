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
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(r => r.Reason)
                .IsRequired()
                .HasMaxLength(500); 

            builder.HasOne(r => r.Comment)
                .WithMany(c => c.Reports) 
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.User) // Report yazan user
            .WithMany(u => u.ReportsWritten) // İstifadəçinin verdiyi reportlar
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict); // İstifadəçi silindikdə report-lar silinməsin

            builder.HasOne(r => r.ReportedUser) // Report olunan user
                .WithMany(u => u.ReportsReceived) // İstifadəçinin report olunduğu hallar
                .HasForeignKey(r => r.ReportedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
