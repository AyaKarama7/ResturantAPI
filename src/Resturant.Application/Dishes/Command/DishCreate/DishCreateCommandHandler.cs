using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Domain.Entities;
using Resturant.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Command.DishCreate
{
    public class DishCreateCommandHandler(IMapper mapper,
        ILogger<DishCreateCommandHandler> logger,IResturantRepository resturantRepository, IDishRepository dishRepository) 
        : IRequestHandler<DishCreateCommand,int>
    {
        public async Task<int> Handle(DishCreateCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Adding a new dish to resturant{request.ResturantId}.");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant == null)
            {
                logger.LogInformation($"Resturant with Id={request.ResturantId} Not Found.");
                return 0;
            }
            var dish = mapper.Map<Dish>(request);
            await dishRepository.AddAsync(dish);
            return dish.Id;
        }
    }
}
