using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException
{
    public class RoleAssignmentException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status500InternalServerError;
        public string ErrorMessage { get; }
        public RoleAssignmentException()
        {
            ErrorMessage = "Role assignment failed.";
        }
        public RoleAssignmentException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
