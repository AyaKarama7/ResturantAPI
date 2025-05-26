using AutoMapper;

namespace Resturant.Application.Dishes.DTOs
{
    public class DishMapper : Profile
    {
        public DishMapper()
        {
            CreateMap<Domain.Entities.Dish, DishDTO>();
        }
    }
}
