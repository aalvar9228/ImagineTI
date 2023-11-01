using AutoMapper;
using Imagine.Business.Exceptions;
using Imagine.Business.Interfaces;
using Imagine.Business.Models;
using Imagine.EntityFramework.Interfaces;

namespace Imagine.Business.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public List<Movie> Search(string? title = null, int page = 1, int pageSize = 10)
        {
            var response = string.IsNullOrEmpty(title) ?
                _movieRepository.Filter(page, pageSize) :
                _movieRepository.Filter(page, pageSize, x => x.Title.ToLower().Contains(title.ToLower()));

            if (!response.Any()) throw new NotFoundException();

            return _mapper.Map<List<Movie>>(response);
        }
    }
}
