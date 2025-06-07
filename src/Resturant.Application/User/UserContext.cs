using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Resturant.Application.User
{
    public class UserContext(IHttpContextAccessor httpContextAccessor):IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not present");
            }
            if (user.Identity == null || user.Identity.IsAuthenticated==false)
            {
                return null;
            }
            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)?.Value ?? string.Empty;
            var roles = user.FindAll(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            return new CurrentUser(userId, email, roles);
        }
    }
}
