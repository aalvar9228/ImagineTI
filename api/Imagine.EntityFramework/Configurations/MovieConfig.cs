using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Imagine.EntityFramework.Entities;

namespace Imagine.EntityFramework.Configurations
{
    public class MovieConfig : IEntityTypeConfiguration<MovieEntity>
    {
        private const string Schema = "imagine";
        public void Configure(EntityTypeBuilder<MovieEntity> builder)
        {
            builder.ToTable("Movie", Schema);

            builder.HasIndex(x => x.Id);
        }
    }
}
