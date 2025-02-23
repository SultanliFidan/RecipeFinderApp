using RecipeFinderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.ExternalServices.Abstractions
{
    public interface IJwtTokenHandler
    {
        Task<string> CreateToken(User user, int hours);
    }
}
