using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Common;
using Resturant.Application.Resturants.DTOs;
using Resturant.Domain.IRepositories;

namespace Resturant.Application.Resturants.Query.GetAllResturants
{
    public class GetAllResturantsQueryHandler(IMapper mapper,
           ILogger<GetAllResturantsQueryHandler> logger, IResturantRepository resturantRepository)
           : IRequestHandler<GetAllResturantsQuery, PagedResult<ResturantDisplayDTO>>
    {
        public async Task<PagedResult<ResturantDisplayDTO>> Handle(GetAllResturantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving all restaurants from the repository.");
            var searchTerm = request.SearchTerm.ToLower();
            var (restaurants,totalCount) = await resturantRepository.GetAllMatchingResultsAsync(searchTerm
                ,request.PageSize,request.PageNumber,request.SortBy,request.SortDirection);  
            var resturantDTOs= restaurants.Select(r => mapper.Map<ResturantDisplayDTO>(r));
            var pagedResult = new PagedResult<ResturantDisplayDTO>(resturantDTOs,
                totalCount,
                request.PageSize,
                request.PageNumber
                );
            logger.LogInformation("Successfully retrieved {Count} restaurants.", totalCount);
            return pagedResult;
        }
    }
}
