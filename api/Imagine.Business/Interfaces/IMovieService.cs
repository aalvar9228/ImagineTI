using Imagine.Business.Models;

namespace Imagine.Business.Interfaces
{
    public interface IMovieService
    {
        List<Movie> Search(string? title = null, int page = 1, int pageSize = 10);
    }
}
