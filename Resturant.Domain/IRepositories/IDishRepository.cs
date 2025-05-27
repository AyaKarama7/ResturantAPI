using Resturant.Domain.Entities;

namespace Resturant.Domain.IRepositories
{
    public interface IDishRepository
    {
        Task<int> AddAsync(Dish dish);
        Task<int> UpdateAsync(Dish dish);
        Task DeleteAsync(Dish dish);
    }
}
