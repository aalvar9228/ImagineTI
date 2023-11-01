using Imagine.EntityFramework.Entities;
using Imagine.EntityFramework.Interfaces;

namespace Imagine.EntityFramework.Repositories
{
    public sealed class MovieRepository : EFRepository<MovieEntity>, IMovieRepository
    {
        public MovieRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
