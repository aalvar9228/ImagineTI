using System.Net;

namespace Imagine.Api.Impl.Models.Responses
{
    public abstract class ApiResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
        public string Message { get; set; }

        public ApiResponse()
        {

        }

        public ApiResponse(T data)
        {
            Data = data;
        }
    }
}
