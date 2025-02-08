using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptioins.UserException
{
    public class AuthorizationException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status401Unauthorized;

        public string ErrorMessage { get; }

        public AuthorizationException()
        {
            ErrorMessage = "User not logged in";
        }

        public AuthorizationException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
