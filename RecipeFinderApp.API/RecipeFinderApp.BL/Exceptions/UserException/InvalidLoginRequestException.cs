using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException
{
    public class InvalidLoginRequestException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }

        public InvalidLoginRequestException()
        {
            ErrorMessage = "Invalid login request.";
        }
        public InvalidLoginRequestException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
