using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Resturant.Application.User.Command.UserAssign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.User.Command.UserUnAssignRole
{
    public class UserUnAssignRoleCommandHandler(ILogger<UserUnAssignRoleCommandHandler> logger, UserManager<Domain.Entities.User> userManager,
    RoleManager<IdentityRole> roleManager)
    : IRequestHandler<UserUnAssignRoleCommand>
    {
        public async Task Handle(UserUnAssignRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"UserUnAssignRoleCommandHandler called with User: {request.UserEmail} and Role: {request.RoleName}");
            var user = await userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
            {
                logger.LogWarning($"User with email {request.UserEmail} not found.");
                throw new ArgumentException($"User with email {request.UserEmail} not found.");
            }
            var role = await roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                logger.LogWarning($"Role {request.RoleName} not found.");
                throw new ArgumentException($"Role {request.RoleName} not found.");
            }
            var result = await userManager.RemoveFromRoleAsync(user, role.Name!);
            if (!result.Succeeded)
            {
                logger.LogError($"Failed to remove role {request.RoleName} from user {request.UserEmail}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                throw new InvalidOperationException($"Failed to remove role {request.RoleName} from user {request.UserEmail}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            logger.LogInformation($"Role {request.RoleName} removed user {request.UserEmail} successfully.");

        }

    }
}
