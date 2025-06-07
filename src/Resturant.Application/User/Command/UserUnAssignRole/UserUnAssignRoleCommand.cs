using MediatR;

namespace Resturant.Application.User.Command.UserUnAssignRole
{
    public class UserUnAssignRoleCommand:IRequest
    {
        public string UserEmail { get; set; } =string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
