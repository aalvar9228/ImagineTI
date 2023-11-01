using System;
using System.Net;

namespace Imagine.Api.Impl.Models.Responses
{
    public class ExceptionApiResponse : ApiResponse<object>
    {
        public ExceptionApiResponse()
        {

        }

        public ExceptionApiResponse(Exception exception, HttpStatusCode statusCode) : base(null)
        {
            Message = exception.Message;
            StatusCode = (int)statusCode;
        }
    }
}
