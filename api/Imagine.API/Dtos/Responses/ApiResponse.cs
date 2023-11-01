namespace Imagine.API.Dtos.Responses
{
    public abstract class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
