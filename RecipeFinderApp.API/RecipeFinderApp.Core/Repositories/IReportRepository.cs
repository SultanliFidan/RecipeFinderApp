using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Repositories
{
    public interface IReportRepository : IGenericRepository<Report>
    {
        Task AddAsync(Report report);
        Task<int> GetReportCountForUserAsync(string reportedUserId);
    }
}
