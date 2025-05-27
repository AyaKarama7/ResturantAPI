using MediatR;
using Resturant.Application.Dishes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Query.GetDishForResturantById
{
    public class GetDishForResturantByIdQuery(int resturantId,int dishId):IRequest<DishDTO>
    {
        public int DishId { get; set; } = dishId;
        public int ResturantId { get; set; } = resturantId;
    }
}
