using Microsoft.AspNetCore.Http;
using RecipeFinderApp.BL.Exceptioins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptions.UserException
{
    public class AccountLockedException : Exception, IBaseException
    {
        public int Code => StatusCodes.Status403Forbidden;
        public string ErrorMessage { get; }

        public AccountLockedException(DateTimeOffset lockoutEnd)
        {
            ErrorMessage = $"Your account is locked. Please wait until {lockoutEnd:yyyy-MMM-dd HH:mm:ss}.";
        }
        public AccountLockedException(string message) : base(message)
        {
            ErrorMessage = message ;
        }
    }
}
