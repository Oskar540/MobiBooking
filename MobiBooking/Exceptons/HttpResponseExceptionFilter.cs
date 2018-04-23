using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace MobiBooking.Exceptions
{
    [Serializable]
    public class HttpResponseExceptionFilter : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        public HttpResponseExceptionFilter(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpResponseExceptionFilter(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public HttpResponseExceptionFilter(int statusCode, Exception inner) : this(statusCode, inner.ToString()) { }

        public HttpResponseExceptionFilter(int statusCode, Object errorObject) : this(statusCode, errorObject.ToString())
        {
        }
    }
}