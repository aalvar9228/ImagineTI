using Imagine.API.Dtos.Responses;
using Imagine.Business.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace Imagine.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
                switch(context.Response.StatusCode)
                {
                    case (int)HttpStatusCode.Unauthorized:
                        throw new UnauthorizedAccessException("Acceso no autorizado");
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case BusinessException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ExceptionApiResponse(exception, code)));
        }
    }
}
