using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Resturant.Application.User.Command.UserAssign
{
    public class UserAssignRoleCommandHandler(ILogger<UserAssignRoleCommandHandler> logger, UserManager<Domain.Entities.User> userManager,
    RoleManager<IdentityRole> roleManager)
    : IRequestHandler<UserAssignRoleCommand>
    {
        public async Task Handle(UserAssignRoleCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"UserAssignRoleCommandHandler called with User: {request.UserEmail} and Role: {request.RoleName}");
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
            var result = await userManager.AddToRoleAsync(user, role.Name!);
            if (!result.Succeeded)
            {
                logger.LogError($"Failed to assign role {request.RoleName} to user {request.UserEmail}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                throw new InvalidOperationException($"Failed to assign role {request.RoleName} to user {request.UserEmail}. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
            logger.LogInformation($"Role {request.RoleName} assigned to user {request.UserEmail} successfully.");

        }
    }
}
