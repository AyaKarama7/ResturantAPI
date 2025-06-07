using AutoMapper;
using Resturant.Application.Dishes.Command.DishCreate;
using Resturant.Application.Dishes.Command.DishUpdate;
using Resturant.Domain.Entities;

namespace Resturant.Application.Dishes.DTOs
{
    public class DishMapper : Profile
    {
        public DishMapper()
        {
            CreateMap<DishCreateCommand, Dish>();
            CreateMap<DishUpdateCommand, Dish>();
            CreateMap<Domain.Entities.Dish, DishDTO>();
        }
    }
}
