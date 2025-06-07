using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Domain.IRepositories;


namespace Resturant.Application.Dishes.Command.DishUpdate
{
    public class DishUpdateCommandHandler
        (IMapper mapper, ILogger<DishUpdateCommandHandler> logger,IResturantRepository resturantRepository,
        IDishRepository dishRepository)
        : IRequestHandler<DishUpdateCommand, int>
    {
        public async Task<int> Handle(DishUpdateCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Update Dish:{request.DishId} in Resturant: {request.ResturantId}.");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if(resturant == null)
            {
                logger.LogWarning($"Restaurant with ID {request.ResturantId} not found.");
                return 0;
            }
            var dish = resturant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if(dish==null)
            {
                logger.LogWarning($"Disht with ID {request.DishId} not found.");
                return 0;
            }
            mapper.Map(request, dish);
            var id=await dishRepository.UpdateAsync(dish);
            return id;
        }
    }
}
