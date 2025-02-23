using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.DTOs.ReportDTOs
{
    public class ReportDto
    {
            public int CommentId { get; set; }  
            public string ReportedUserId { get; set; } = null!;
            public string Reason { get; set; } = null!; 
        

    }
}
