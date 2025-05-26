using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Entities;

namespace Resturant.Infrastructure.Data
{
    internal class ResturantDbContext(DbContextOptions<ResturantDbContext> options) :DbContext(options)
    {
        internal DbSet<Domain.Entities.Resturant> Resturants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Resturant>()
                .OwnsOne(r => r.Address);
            modelBuilder.Entity<Domain.Entities.Resturant>()
                .HasMany<Dish>(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.ResturantId);
        }
    }
}
