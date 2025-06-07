using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Application.Resturants.DTOs;
using Resturant.Domain.IRepositories;

namespace Resturant.Application.Resturants.Query.GetAllResturants
{
    public class GetAllResturantsQueryHandler(IMapper mapper,
        ILogger<ResturantCreateCommandHandler> logger, IResturantRepository resturantRepository)
        : IRequestHandler<GetAllResturantsQuery, IEnumerable<ResturantDisplayDTO>>
    {
        public async Task<IEnumerable<ResturantDisplayDTO>> Handle(GetAllResturantsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retrieving all restaurants from the repository.");
            return await resturantRepository.GetAllAsync()
                .ContinueWith(task => task.Result.Select(r => mapper.Map<ResturantDisplayDTO>(r)));
        }
    }
}
