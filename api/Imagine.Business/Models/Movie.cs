namespace Imagine.Business.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double? Rate { get; set; }
    }
}
