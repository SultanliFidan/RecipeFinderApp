using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using RecipeFinderApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.DAL.Repositories
{
    public class ReportRepository : GenericRepository<Report>, IReportRepository
    { 
        readonly RecipeFinderDbContext _context;
        readonly UserManager<User> _userManager;
        public ReportRepository(RecipeFinderDbContext context, UserManager<User> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddAsync(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

            
            int reportCount = await _context.Reports
                .CountAsync(r => r.ReportedUserId == report.ReportedUserId);

            if (reportCount >= 5) 
            {
                var reportedUser = await _userManager.FindByIdAsync(report.ReportedUserId);
                if (reportedUser != null)
                {
                    reportedUser.LockoutEnd = DateTime.UtcNow.AddYears(100); 
                    await _userManager.UpdateAsync(reportedUser);

                    var userComments = await _context.RecipeComments
                        .Where(c => c.UserId == report.ReportedUserId)
                        .ToListAsync();

                    foreach (var comment in userComments)
                    {
                        comment.IsDeleted = true;
                    }
                }
            }

            var reportedComment = await _context.RecipeComments
                .FirstOrDefaultAsync(c => c.Id == report.CommentId);

            if (reportedComment != null)
            {
                reportedComment.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
        }


        public async Task<int> GetReportCountForUserAsync(string reportedUserId)
        {
            return await _context.Reports
                .CountAsync(r => r.ReportedUserId == reportedUserId);
        }
    }
}
