using Resturant.Domain.IRepositories;
using Resturant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Resturant.Infrastructure.Repositories
{
    internal class ResturantRepository(ResturantDbContext context) : IResturantRepository
    {
        public async Task<int> AddAsync(Domain.Entities.Resturant resturant)
        {
            context.Resturants.Add(resturant);
            await context.SaveChangesAsync();
            return resturant.Id;
        }

        public async Task<int> UpdateAsync(Domain.Entities.Resturant resturant)
        {
            await context.SaveChangesAsync();
            return resturant.Id;
        }
        public async Task DeleteAsync(Domain.Entities.Resturant resturant)
        {
            context.Resturants.Remove(resturant);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Resturant>> GetAllAsync()
        {
            var resturants = await context.Resturants.ToListAsync();
            return resturants;
        }

        public async Task<Domain.Entities.Resturant?> GetByIdAsync(int id)
        {
            var resturant= await context.Resturants
                .Include(r => r.Dishes)
                .FirstOrDefaultAsync(r => r.Id == id);
            return resturant;
        }
    }
}
