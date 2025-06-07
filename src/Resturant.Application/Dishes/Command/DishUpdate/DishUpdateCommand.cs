using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Command.DishUpdate
{
    public class DishUpdateCommand(int resturantId,int dishId):IRequest<int>
    {
        public int ResturantId { get; set; } = resturantId;
        public int DishId { get; set; } = dishId;
        public string Name { get; set; } = default!;
        public string Description { get; set; }=default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }
    }
}
