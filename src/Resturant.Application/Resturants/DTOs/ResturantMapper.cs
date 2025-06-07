using AutoMapper;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Application.Resturants.Commands.ResturantUpdate;
using Resturant.Domain.Entities;
namespace Resturant.Application.Resturants.DTOs
{
    public class ResturantMapper : Profile
    {
        public ResturantMapper()
        {
            CreateMap<ResturantCreateCommand, Domain.Entities.Resturant>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }));
            CreateMap<ResturantUpdateCommand, Domain.Entities.Resturant>();

            CreateMap<Domain.Entities.Resturant, ResturantDisplayDTO>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));
        }
    }
}
