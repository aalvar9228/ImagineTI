using Imagine.Api.Impl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imagine.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> SearchAsync(string title, int page = 1, int pageSize = 10);
    }
}
