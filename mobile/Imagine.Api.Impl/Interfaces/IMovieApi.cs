using Imagine.Api.Impl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imagine.Api.Impl.Interfaces
{
    public interface IMovieApi
    {
        Task<List<Movie>> SearchAsync(string title = null, int page = 1, int pageSize = 10);
    }
}
