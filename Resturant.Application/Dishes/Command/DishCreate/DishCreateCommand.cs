﻿using MediatR;

namespace Resturant.Application.Dishes.Command.DishCreate
{
    public class DishCreateCommand:IRequest<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }
        public int ResturantId { get; set; }
    }
}
