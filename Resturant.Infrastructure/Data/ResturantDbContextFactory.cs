using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Resturant.Infrastructure.Data
{
    internal class ResturantDbContextFactory : IDesignTimeDbContextFactory<ResturantDbContext>
    {
        public ResturantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ResturantDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ResturantsDB;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");
            return new ResturantDbContext(optionsBuilder.Options);
        }
    }
}
