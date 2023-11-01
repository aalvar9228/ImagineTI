using System.Net;

namespace Imagine.API.Dtos.Responses
{
    public class ExceptionApiResponse : ApiResponse<object>
    {
        public ExceptionApiResponse(Exception exception, HttpStatusCode statusCode) : base(null)
        {
            Message = exception.Message;
            StatusCode = (int)statusCode;
        }
    }
}
