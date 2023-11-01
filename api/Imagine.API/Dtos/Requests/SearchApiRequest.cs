using System.ComponentModel.DataAnnotations;

namespace Imagine.API.Dtos.Requests
{
    public class SearchApiRequest
    {
        public string? Title { get; set; }

        [Required]
        public int Page { get; set; } = 1;

        [Required]
        public int PageSize { get; set; } = 10;
    }
}
