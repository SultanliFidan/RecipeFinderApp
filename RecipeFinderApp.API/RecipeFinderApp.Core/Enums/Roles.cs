using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.Core.Enums
{
    public enum Roles
    {
        Viewer = 1,
        Publisher = 2,
        Admin = Publisher | Viewer
    }
}
