using Imagine.EntityFramework.Configurations;
using Imagine.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Imagine.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        #region Data Sets

        public DbSet<MovieEntity> Movies { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.ApplyConfiguration(new MovieConfig());
        }
    }
}
