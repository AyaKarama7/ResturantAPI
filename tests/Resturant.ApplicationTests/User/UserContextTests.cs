using Xunit;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Resturant.Domain.Constants;
using FluentAssertions;
namespace Resturant.Application.User.Tests;
public class UserContextTests
{
    [Fact()]
    public void GetCurrentUserTest_WithAuthentcatedUser_ShouldReturnCurrentUser()
    {
        var context = new HttpContextAccessor();
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Email,"testuser@gmail.com"),
            new Claim(ClaimTypes.Role, UserRoles.Admin),
            new Claim(ClaimTypes.Role, UserRoles.User)
        };
        //create a user object that holds identity information and claims.
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims,"TestAuth"));
        //assign the user to the HttpContext of the mock IHttpContextAccessor.
        httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext { User = user });
        var userContext = new UserContext(httpContextAccessor.Object);
        //act
        var currentUser = userContext.GetCurrentUser();
        //assert
        currentUser.Should().NotBeNull();
        currentUser!.Id.Should().Be("123");
        currentUser!.Email.Should().Be("testuser@gmail.com");
        currentUser!.Roles.Should().Contain(UserRoles.Admin);
        currentUser!.Roles.Should().Contain(UserRoles.User);
    }
    [Fact()]
    public void GetCurrentUserTest_WithUnauthenticatedUser_ShouldReturnNull()
    {
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, "123"),
            new Claim(ClaimTypes.Email,"testuser@gmail.com"),
            new Claim(ClaimTypes.Role, UserRoles.Admin),
            new Claim(ClaimTypes.Role, UserRoles.User)
        };
        //create a user object that holds identity information and claims.
        var user = new ClaimsPrincipal(new ClaimsIdentity(claims));
        //assign the user to the HttpContext of the mock IHttpContextAccessor.
        httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext { User = user });
        var userContext = new UserContext(httpContextAccessor.Object);
        //act
        var currentUser = userContext.GetCurrentUser();
        //assert
        currentUser.Should().BeNull();
    }
    [Fact()]
    public void GetCurrentUserTest_WithNoUser_ShouldThrowInvalidOperationException()
    {
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        //set up the mock to return null for HttpContext
        httpContextAccessor.Setup(x => x.HttpContext).Returns((HttpContext?)null);
        var userContext = new UserContext(httpContextAccessor.Object);
        //act
        Action act = () => userContext.GetCurrentUser();
        //assert
        act.Should().Throw<InvalidOperationException>().WithMessage("User context is not present");
    }
    [Fact()]
    public void GetCurrentUserTest_WithNoIdentity_ShouldThrowInvalidOperationException()
    {
        var httpContextAccessor = new Mock<IHttpContextAccessor>();
        //create a user object that holds identity information and claims.
        var user = new ClaimsPrincipal(new ClaimsIdentity());
        //assign the user to the HttpContext of the mock IHttpContextAccessor.
        httpContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext { User = user });
        var userContext = new UserContext(httpContextAccessor.Object);
        //act
        var currentUser = userContext.GetCurrentUser();
        //assert
        currentUser.Should().BeNull();
    }
}