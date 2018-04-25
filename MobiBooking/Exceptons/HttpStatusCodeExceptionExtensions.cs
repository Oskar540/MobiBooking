using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobiBooking.Exceptons
{
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpStatusCodeExceptionExtensions
    {

        public static IApplicationBuilder UseHttpStatusCodeException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}
