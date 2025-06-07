using Resturant.Domain.IRepositories;
using Resturant.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Constants;

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
        public async Task<(IEnumerable<Domain.Entities.Resturant>,int)> GetAllMatchingResultsAsync(string searchTerm,
            int pageSize,int pageNumber,string? sortby,SortDirection sortDirection)
        {
            var baseResult = context.Resturants.Where(r => r.Name.ToLower().Contains(searchTerm)
                || r.Description.ToLower().Contains(searchTerm)||r.Category.ToLower().Contains(searchTerm));

            var totalCount = await baseResult.CountAsync();

            if(sortby != null)
            {
                if (sortDirection == SortDirection.Ascending)
                {
                    baseResult = baseResult.OrderBy(r => EF.Property<object>(r, sortby));
                }
                else
                {
                    baseResult = baseResult.OrderByDescending(r => EF.Property<object>(r, sortby));
                }
            }
            else
            {
                baseResult = baseResult.OrderBy(r => r.Name);
            }

            var resturants=await baseResult
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (resturants,totalCount);
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
