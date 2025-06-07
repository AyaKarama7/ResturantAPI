using FluentAssertions;
using Resturant.Domain.Constants;
using Xunit;
namespace Resturant.Application.User.Tests;
public class CurrentUserTests
{
    [Theory()]
    [InlineData(UserRoles.Admin)]
    [InlineData(UserRoles.User)]
    public void IsInRoleTest_WithMatchingRole_ShouldReturnTrue(string roleName)
    {
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin,UserRoles.User]);
        var result = currentUser.IsInRole(roleName);
        result.Should().BeTrue();

    }
    [Fact()]
    public void IsInRoleTest_WithNoMatchingRoleCaseSensitive_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin, UserRoles.User]);
        var result = currentUser.IsInRole(UserRoles.Admin.ToLower());
        result.Should().BeFalse();
    }
    [Fact()]
    public void IsInRoleTest_WithNoMatchingRoleDifferentRole_ShouldReturnFalse()
    {
        var currentUser = new CurrentUser("1", "testuser@gmail.com", [UserRoles.Admin, UserRoles.User]);
        var result = currentUser.IsInRole(UserRoles.Owner);
        result.Should().BeFalse();
    }
}