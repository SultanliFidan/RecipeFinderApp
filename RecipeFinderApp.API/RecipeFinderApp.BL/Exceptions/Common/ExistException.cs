using Microsoft.AspNetCore.Http;
using RecipeFinderApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinderApp.BL.Exceptioins.Common
{
    public class ExistException<T> : Exception, IBaseException where T : BaseEntity
    {
        public int Code => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; }
        const string _message = "is exist";

        public ExistException() : base(typeof(T).Name + _message)
        {
            ErrorMessage = typeof(T).Name + _message;
        }
        public ExistException(string message) : base(message)
        {
            ErrorMessage = message;
        }
    }
}
