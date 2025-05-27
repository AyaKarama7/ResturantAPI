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

namespace Resturant.Application.Dishes.Query.GetAllDishesForResturant
{
    public class GetAllDishesForResturantQueryHandler
        (IMapper mapper, ILogger<GetAllDishesForResturantQueryHandler> logger,
        IResturantRepository resturantRepository)
        : IRequestHandler<GetAllDishesForResturantQuery, IEnumerable<DishDTO>>
    {
        public async Task<IEnumerable<DishDTO>> Handle(GetAllDishesForResturantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Retriving Al Dishes of resturant: {request.ResturantId}");
            var resturant = await resturantRepository.GetByIdAsync(request.ResturantId);
            if (resturant == null)
            {
                logger.LogInformation($"Resturant with Id={request.ResturantId} Not Found.");
                return null;
            }
            var dishes = mapper.Map<IEnumerable<DishDTO>>(resturant.Dishes);
            return dishes;
        }
    }
}
