using Imagine.API.Extensions;
using Imagine.API.Middlewares;
using Imagine.API.Options;
using Imagine.Business.Extensions;
using Imagine.Business.Profiles;

namespace Imagine.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<OAuth>(
                builder.Configuration.GetSection(OAuth.Section));

            builder.Services.AddAutoMapper(typeof(BusinessProfile));
            builder.Services.ConfigureDBContext(builder.Configuration);
            builder.Services.AddBusinessDependencies();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}