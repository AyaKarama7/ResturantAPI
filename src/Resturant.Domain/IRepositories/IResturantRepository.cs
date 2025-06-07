using Resturant.Domain.Constants;


namespace Resturant.Domain.IRepositories
{
    public interface IResturantRepository
    {
        Task<IEnumerable<Domain.Entities.Resturant>> GetAllAsync();
        Task<Domain.Entities.Resturant?> GetByIdAsync(int id);
        Task<int> AddAsync(Domain.Entities.Resturant resturant);
        Task DeleteAsync(Domain.Entities.Resturant resturant);
        Task<int> UpdateAsync(Domain.Entities.Resturant resturant);
        Task<(IEnumerable<Domain.Entities.Resturant>, int)> GetAllMatchingResultsAsync(string searchTerm,
            int pageSize, int pageNumber,string? sortBy,SortDirection sortDirection);
    }
}
