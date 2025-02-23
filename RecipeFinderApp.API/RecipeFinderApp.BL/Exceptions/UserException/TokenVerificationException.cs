using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException
{
    public class TokenVerificationException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }

        public TokenVerificationException()
        {
            ErrorMessage = "Token verification failed.";
        }
        public TokenVerificationException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
