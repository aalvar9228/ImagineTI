using Imagine.API.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace Imagine.API.Filters
{
    public class OAuthFilter : ActionFilterAttribute
    {
        private const string ClientIdHeader = "ClientId";
        private const string ClientSecretHeader = "ClientSecret";

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var services = context.HttpContext.RequestServices;
            var auth = services.GetService<IOptions<OAuth>>()!.Value;

            var headers = context.HttpContext.Request.Headers;
            if (!headers.ContainsKey(ClientIdHeader) ||
                !headers.ContainsKey(ClientSecretHeader) ||
                auth.ClientId != headers[ClientIdHeader] ||
                auth.ClientSecret != headers[ClientSecretHeader])
            {
                throw new UnauthorizedAccessException();
            }

            await base.OnActionExecutionAsync(context, next);
        }
    }
}
