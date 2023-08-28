using Microsoft.EntityFrameworkCore;
using SuperPets.Domain.Animals;

namespace SuperPets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>();

            base.OnModelCreating(builder);
        }

    }
}
