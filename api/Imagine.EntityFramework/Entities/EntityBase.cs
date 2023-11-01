using System.ComponentModel.DataAnnotations;

namespace Imagine.EntityFramework.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}
