namespace Resturant.Application.Common
{
    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T>items,int totalCount,int pageSize,int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ItemFrom = (pageNumber - 1) * pageSize + 1;
            ItemTo = Math.Min(pageNumber * pageSize, totalCount);
        }
        public IEnumerable<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsCount { get; set; }
        public int ItemFrom { get; set; }
        public int ItemTo { get; set; }
    }
}
