using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace MobiBooking.Exceptions
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; }

        public HttpResponseException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpResponseException(int statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
            this.ContentType = message;
        }

        public HttpResponseException(int statusCode, Exception inner) : this(statusCode, inner.ToString())
        {
        }

        public HttpResponseException(int statusCode, Object errorObject) : this(statusCode, errorObject.ToString())
        {
        }
    }
}