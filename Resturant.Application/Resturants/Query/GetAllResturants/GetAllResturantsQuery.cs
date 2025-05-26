using MediatR;
using Resturant.Application.Resturants.DTOs;

namespace Resturant.Application.Resturants.Query.GetAllResturants
{
    public class GetAllResturantsQuery : IRequest<IEnumerable<ResturantDisplayDTO>>
    {
    }
}
