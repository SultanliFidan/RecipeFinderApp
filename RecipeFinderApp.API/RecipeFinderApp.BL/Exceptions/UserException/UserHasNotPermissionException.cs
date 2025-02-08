using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptioins.UserException
{
    public class UserHasNotPermissionException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status403Forbidden;

        public string ErrorMessage { get; }
        public UserHasNotPermissionException()
        {
            ErrorMessage = "User has no permission";
        }

        public UserHasNotPermissionException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
