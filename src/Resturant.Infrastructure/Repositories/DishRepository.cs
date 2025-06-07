using Resturant.Domain.Entities;
using Resturant.Domain.IRepositories;
using Resturant.Infrastructure.Data;

namespace Resturant.Infrastructure.Repositories
{
    internal class DishRepository(ResturantDbContext context): IDishRepository
    {
        public async Task<int> AddAsync(Dish dish)
        {
            context.Dishes.Add(dish);
            await context.SaveChangesAsync();
            return dish.Id;
        }

        public async Task DeleteAsync(Dish dish)
        {
            context.Dishes.Remove(dish);
            await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Dish dish)
        {
            await context.SaveChangesAsync();
            return dish.Id;
        }
    }
}
