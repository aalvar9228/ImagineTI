using Imagine.Business.Models;

namespace Imagine.API.Dtos.Responses
{
    public class SearchApiResponse : ApiResponse<List<Movie>>
    {
        public SearchApiResponse(List<Movie> data) : base(data)
        {
        }
    }
}
