using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application.User.Command.UserAssign;
using Resturant.Application.User.Command.UserUnAssignRole;
using Resturant.Domain.Constants;

namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController(IMediator mediator) : ControllerBase
    {
        [HttpPost("user-role")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRoleAsync([FromBody] UserAssignRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("user-role-remove")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UnAssignUserRoleAsync([FromBody] UserUnAssignRoleCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
    }
}
