using RecipeFinderApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Extensions
{
    
        public static class RoleExtension
        {
            public static string GetRole(this Roles role)
            {
                return role switch
                {
                    Roles.Admin => nameof(Roles.Admin),
                    Roles.Publisher => nameof(Roles.Publisher),
                    Roles.Viewer => nameof(Roles.Viewer)
                };
            }
        }
    }

