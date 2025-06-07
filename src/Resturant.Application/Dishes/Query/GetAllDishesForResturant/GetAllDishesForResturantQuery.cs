using MediatR;
using Resturant.Application.Dishes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Query.GetAllDishesForResturant
{
    public class GetAllDishesForResturantQuery(int resturantId) : IRequest<IEnumerable<DishDTO>>
    {
        public int ResturantId { get; set; } = resturantId;
    }
}
