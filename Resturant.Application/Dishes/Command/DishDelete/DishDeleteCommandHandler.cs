using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Command.DishDelete
{
    public class DishDeleteCommandHandler(ILogger<DishDeleteCommandHandler> logger, IDishRepository dishRepository
        ,IResturantRepository resturantRepository)
        : IRequestHandler<DishDeleteCommand, bool>
    {
        public async Task<bool> Handle(DishDeleteCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Dlete Dish:{request.DishId} from Resturant: {request.ResturantId}.");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant == null)
            {
                logger.LogWarning($"Restaurant with ID {request.ResturantId} not found.");
                return false;
            }
            var dish = resturant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null)
            {
                logger.LogWarning($"Disht with ID {request.DishId} not found.");
                return false;
            }
            await dishRepository.DeleteAsync(dish);
            return true;
        }
    }
}
