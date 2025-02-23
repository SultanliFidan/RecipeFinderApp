using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException;

internal class UserNotFoundException : Exception, IBaseException
{
    public int Code => StatusCodes.Status404NotFound;

    public string ErrorMessage { get; }

    public UserNotFoundException()
    {
        ErrorMessage = "User not found";
    }

    public UserNotFoundException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}

