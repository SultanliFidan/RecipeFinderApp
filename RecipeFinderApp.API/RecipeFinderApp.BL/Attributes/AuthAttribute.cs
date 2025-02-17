using Microsoft.AspNetCore.Mvc.Filters;
using RecipeFinderApp.BL.Constants;
using RecipeFinderApp.BL.Exceptioins.UserException;
using RecipeFinderApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthAttribute : Attribute, IAsyncActionFilter
    {
        private int access;
        public AuthAttribute(Roles role)
        {
            access = (int)role;   
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var value = context.HttpContext.User.FindFirst(x => x.Type == ClaimType.Role)!.Value;
            if (value == null) throw new AuthorizationException();
            int role = Convert.ToInt32(value);

            if ((role & access) != access) 
                throw new UserHasNotPermissionException();
            await next();
        }
    }
}
