using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturant.Application.User;
using Resturant.Domain.IRepositories;


namespace Resturant.Application.Resturants.Commands.ResturantCreate
{
    public class ResturantCreateCommandHandler(IMapper mapper, 
        ILogger<ResturantCreateCommandHandler> logger, IResturantRepository resturantRepository,
        IUserContext userContext) 
        : IRequestHandler<ResturantCreateCommand, int>
    {
        public async Task<int> Handle(ResturantCreateCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();
            logger.LogInformation("Adding a new restaurant to the repository.");
            var resturant = mapper.Map<Domain.Entities.Resturant>(request);
            resturant.OwnerId = currentUser?.Id ?? throw new InvalidOperationException("Current user is not authenticated.");
            int addedResturantId = await resturantRepository.AddAsync(resturant);
            logger.LogInformation($"Restaurant with ID {addedResturantId} added successfully.");
            return addedResturantId;
        }
    }
}
