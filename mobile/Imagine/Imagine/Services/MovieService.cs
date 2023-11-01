using Imagine.Api.Impl.Interfaces;
using Imagine.Api.Impl.Models;
using Imagine.Constants;
using Imagine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imagine.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieApi _movieApi;
        private readonly ICacheService _cacheService;

        public MovieService(IMovieApi movieApi, ICacheService cacheService)
        {
            _movieApi = movieApi;
            _cacheService = cacheService;
        }

        public async Task<List<Movie>> SearchAsync(string title, int page = 1, int pageSize = 10)
        {
            try
            {
                var key = $"{StorageKeys.Movies}?title={title}&page={page}&pageSize={pageSize}";
                var cacheData = await _cacheService.GetAsync<List<Movie>>(key);
                if (cacheData?.Any() ?? false) return cacheData;

                if (cacheData == null) cacheData = new List<Movie>();

                var response = await _movieApi.SearchAsync(title, page, pageSize);
                cacheData.AddRange(response);

                await _cacheService.SetAsync(key, cacheData);

                return cacheData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at {nameof(SearchAsync)}: {ex}");
                throw ex;
            }
        }
    }
}
