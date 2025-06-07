using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Entities;
using Moq;
using Resturant.Infrastructure.Seeders;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.DependencyInjection;
namespace Resturant.API.Controllers.Tests;
public class ResturantControllerTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly Mock<IResturantSeeder> _resturantSeeder;
    public ResturantControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            _ = builder.ConfigureTestServices(service =>
            {
                service.Replace(ServiceDescriptor.Scoped(typeof(IResturantSeeder), _ => _resturantSeeder.Object));
            }
            );
        }
        );
        #region what is _factory
        // This will create a test server for the API, 
        // allowing us to send HTTP requests to it.
        // This is useful for integration testing.
        // // The Program class is the entry point of the API,
        // // and it will be used to configure the test server.
        // // // The factory will create a new instance of the Program class
        // // // and use it to configure the test server.
        // // // // The factory will also create a new instance of the HttpClient class,
        // // // // which will be used to send HTTP requests to the test server 
        #endregion
    }

    [Fact()]
    public async Task GetAllTest_ForValidRequest_Return200Ok()
    {
        // Arrange
        var client = _factory.CreateClient();
        // Act
        var response = await client.GetAsync("/api/resturant");
        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
    [Fact()]
    public async Task GetByIdTest_ForValidRequest_Return200Ok()
    {
        // Arrange
        var client = _factory.CreateClient();
        // Act
        var response = await client.GetAsync("/api/resturant/4");
        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
    [Fact()]
    public async Task GetByIdTest_ForInvalidRequest_Return404NotFound()
    {
        // Arrange
        var client = _factory.CreateClient();
        // Act
        var response = await client.GetAsync("/api/resturant/999");
        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }
}