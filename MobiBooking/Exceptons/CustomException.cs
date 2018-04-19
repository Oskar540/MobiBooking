using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Exceptions
{
    [Serializable]
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {   
        public CustomExceptionFilter() : base()
        {
        }
        
    }
}
