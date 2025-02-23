using RecipeFinderApp.BL.DTOs.ReportDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Abstractions
{
    public interface IReportService
    {
        Task AddReportAsync(ReportDto reportDto, string userId);
        Task<int> GetReportCountForUserAsync(string reportedUserId);
        
    }
}
