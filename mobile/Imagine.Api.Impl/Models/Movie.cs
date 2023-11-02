using System;

namespace Imagine.Api.Impl.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rate { get; set; }
        public string CoverImage { get; set; }
    }
}
