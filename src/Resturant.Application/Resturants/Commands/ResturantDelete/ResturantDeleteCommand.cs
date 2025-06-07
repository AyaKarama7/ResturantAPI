using MediatR;

namespace Resturant.Application.Resturants.Commands.ResturantDelete
{
    public class ResturantDeleteCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;
    }
}
