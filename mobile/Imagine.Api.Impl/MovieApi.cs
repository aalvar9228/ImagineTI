using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Imagine.Api.Impl.Interfaces;
using Imagine.Api.Impl.Models;
using Imagine.Api.Impl.Models.Responses;

namespace Imagine.Api.Impl
{
    public class MovieApi : IMovieApi
    {
        private const string BaseUrl = "https://imagine-apps-interview.azurewebsites.net/api/";
        private const string ClientId = "f59894a8-787b-11ee-b962-0242ac120002";
        private const string ClientSecret = "0a5f968d-7419-4aa5-a0e3-3a2669dc1cc0";

        public async Task<List<Movie>> SearchAsync(string title = null, int page = 1, int pageSize = 10)
        {
            try
            {
                var result = await BaseUrl
                    .AppendPathSegment("movies")
                    .AppendPathSegment("search")
                    .SetQueryParam("title", title)
                    .SetQueryParam("page", page)
                    .SetQueryParam("pageSize", pageSize)
                    .WithHeader("ClientId", ClientId)
                    .WithHeader("ClientSecret", ClientSecret)
                    .GetJsonAsync<SearchApiResponse>();

                return result.Data ?? new List<Movie>();
            }
            catch (FlurlHttpException fhe)
            {
                if(fhe.StatusCode == (int)HttpStatusCode.NotFound) return new List<Movie>();
                var errorResponse = await fhe.GetResponseJsonAsync<ExceptionApiResponse>();
                throw new Exception(errorResponse.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at {nameof(SearchAsync)}: {ex}");
                throw ex;
            }
        }
    }
}
