using MediatR;
namespace Resturant.Application.User.Command.UserAssign
{
    public class UserAssignRoleCommand:IRequest
    {
        public string UserEmail { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
