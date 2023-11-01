using Imagine.Business.Interfaces;
using Imagine.Business.Services;
using Imagine.EntityFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Imagine.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddEntityFrameworkDependencies();

            services.AddTransient<IMovieService, MovieService>();
        }
    }
}
