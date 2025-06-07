using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Command.DishDelete
{
    public class DishDeleteCommand(int resturantId,int dishId):IRequest<bool>
    {
        public int ResturantId { get; set; }=resturantId;
        public int DishId { get; set;} = dishId;
    }
}
