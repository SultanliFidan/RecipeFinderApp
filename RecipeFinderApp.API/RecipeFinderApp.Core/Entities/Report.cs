using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Entities
{
    public class Report : BaseEntity
    {
        public int CommentId { get; set; }
        public string UserId { get; set; } = null!;
        public string ReportedUserId { get; set; } = null!;
        public string Reason { get; set; } = null!;
        public RecipeComment Comment { get; set; } = null!;
        public User User { get; set; } = null!; 
        public User ReportedUser { get; set; } = null!; 

    }
}
