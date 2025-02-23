using RecipeFinderApp.BL.DTOs.ReportDTOs;
using RecipeFinderApp.BL.Services.Abstractions;
using RecipeFinderApp.Core.Entities;
using RecipeFinderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Services.Implements
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task AddReportAsync(ReportDto reportDto, string userId)
        {
            var report = new Report
            {
                CommentId = reportDto.CommentId,
                UserId = userId,
                ReportedUserId = reportDto.ReportedUserId,
                Reason = reportDto.Reason
            };

            await _reportRepository.AddAsync(report);
        }

        public async Task<int> GetReportCountForUserAsync(string reportedUserId)
        {
            return await _reportRepository.GetReportCountForUserAsync(reportedUserId);
        }
    }

}
