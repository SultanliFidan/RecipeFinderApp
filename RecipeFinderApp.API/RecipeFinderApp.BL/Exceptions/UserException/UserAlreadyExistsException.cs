using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException
{
    public class UserAlreadyExistsException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; }

        public UserAlreadyExistsException()
        {
            ErrorMessage = "User already exists with this email.";
        }
        public UserAlreadyExistsException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
