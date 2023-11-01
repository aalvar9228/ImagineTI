using Imagine.API.Dtos.Requests;
using Imagine.API.Dtos.Responses;
using Imagine.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Imagine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("search")]
        public ActionResult<SearchApiResponse> Search([FromQuery]SearchApiRequest request)
        {
            var result = _movieService.Search(request.Title, request.Page, request.PageSize);
            return Ok(new SearchApiResponse(result));
        }
    }
}
