using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Resturant.Application.Dishes.DTOs;
using Resturant.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Query.GetDishForResturantById
{
    public class GetDishForResturantByIdQueryHandler
        (ILogger<GetDishForResturantByIdQueryHandler> logger, IMapper mapper,
        IResturantRepository resturantRepository)
        : IRequestHandler<GetDishForResturantByIdQuery, DishDTO>
    {
        public async Task<DishDTO> Handle(GetDishForResturantByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Get Dish {request.DishId} from Resturant {request.ResturantId}.");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if(resturant==null)
            {
                logger.LogInformation($"Resturant with Id={request.ResturantId} Not Found.");
                return null;
            }
            var dish = resturant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if(dish==null)
            {
                logger.LogInformation($"Dish with Id={request.DishId} Not Found in this resturant.");
                return null;
            }
            return mapper.Map<DishDTO>(dish);
        }
    }
}
