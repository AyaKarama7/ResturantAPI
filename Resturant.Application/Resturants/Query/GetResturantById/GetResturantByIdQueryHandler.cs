using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Application.Resturants.DTOs;
using Resturant.Domain.IRepositories;

namespace Resturant.Application.Resturants.Query.GetResturantById
{
    public class GetResturantByIdQueryHandler(IMapper mapper,
        ILogger<ResturantCreateCommandHandler> logger, IResturantRepository resturantRepository)
        : IRequestHandler<GetResturantByIdQuery, ResturantDisplayDTO?>
    {

        public async Task<ResturantDisplayDTO?> Handle(GetResturantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Retrieving restaurant with ID {request.Id} from the repository.");
            return await resturantRepository.GetByIdAsync(request.Id)
                .ContinueWith(task => task.Result != null ? mapper.Map<ResturantDisplayDTO>(task.Result) : null);
        }
    }
}
