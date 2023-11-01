using System.ComponentModel.DataAnnotations;

namespace Imagine.EntityFramework.Entities
{
    public sealed class MovieEntity : EntityBase
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public double? Rate { get; set; }
    }
}
