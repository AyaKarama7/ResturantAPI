using MediatR;
using Resturant.Application.Common;
using Resturant.Application.Resturants.DTOs;
using Resturant.Domain.Constants;

namespace Resturant.Application.Resturants.Query.GetAllResturants
{
    public class GetAllResturantsQuery : IRequest<PagedResult<ResturantDisplayDTO>>
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; } 
    }
}
