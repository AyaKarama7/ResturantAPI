using MediatR;
using Resturant.Application.Resturants.DTOs;

namespace Resturant.Application.Resturants.Query.GetResturantById
{
    public class GetResturantByIdQuery(int id):IRequest<ResturantDisplayDTO?>
    {
        public int Id { get; set; } = id;
    }
}
