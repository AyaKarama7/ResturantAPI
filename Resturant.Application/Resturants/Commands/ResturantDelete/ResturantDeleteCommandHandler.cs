using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Domain.IRepositories;

namespace Resturant.Application.Resturants.Commands.ResturantDelete
{
    public class ResturantDeleteCommandHandler(
        ILogger<ResturantCreateCommandHandler> logger, IResturantRepository resturantRepository)
        : IRequestHandler<ResturantDeleteCommand, bool>
    {
        public async Task<bool> Handle(ResturantDeleteCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant with ID {request.Id} from the repository.");
            var resturant = await resturantRepository.GetByIdAsync(request.Id);
            if (resturant == null)
            {
                logger.LogWarning($"Restaurant with ID {request.Id} not found.");
                return false;
            }
            resturantRepository.DeleteAsync(resturant);
            return true; ;
        }
    }
}
