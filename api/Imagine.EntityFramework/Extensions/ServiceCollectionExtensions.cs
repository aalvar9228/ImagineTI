using Imagine.EntityFramework.Interfaces;
using Imagine.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Imagine.EntityFramework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFrameworkDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddTransient<IMovieRepository, MovieRepository>();
        }
    }
}
