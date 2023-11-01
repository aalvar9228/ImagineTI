using System.Net;

namespace Imagine.API.Dtos.Responses
{
    public abstract class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
        public string? Message { get; set; }

        public ApiResponse(T? data) 
        { 
            Data = data;
        }
    }
}
