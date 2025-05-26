using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Domain.IRepositories;


namespace Resturant.Application.Resturants.Commands.ResturantCreate
{
    public class ResturantCreateCommandHandler(IMapper mapper, 
        ILogger<ResturantCreateCommandHandler> logger, IResturantRepository resturantRepository) 
        : IRequestHandler<ResturantCreateCommand, int>
    {
        public async Task<int> Handle(ResturantCreateCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Adding a new restaurant to the repository.");
            var resturant = mapper.Map<Domain.Entities.Resturant>(request);
            int addedResturantId = await resturantRepository.AddAsync(resturant);
            logger.LogInformation($"Restaurant with ID {addedResturantId} added successfully.");
            return addedResturantId;
        }
    }
}
