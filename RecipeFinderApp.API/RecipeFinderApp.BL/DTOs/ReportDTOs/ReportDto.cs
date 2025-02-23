using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.ReportDTOs
{
    public class ReportDto
    {
            public int CommentId { get; set; }  // Report olunan şərhin ID-si
            public string ReportedUserId { get; set; } = null!; // Report olunan istifadəçinin ID-si
            public string Reason { get; set; } = null!; // Reportun səbəbi
        

    }
}
