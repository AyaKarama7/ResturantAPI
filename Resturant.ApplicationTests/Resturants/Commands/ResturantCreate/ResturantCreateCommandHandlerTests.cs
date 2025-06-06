using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Resturant.Application.User;
using Resturant.Domain.Constants;
using Resturant.Domain.IRepositories;
using Xunit;

namespace Resturant.Application.Resturants.Commands.ResturantCreate.Tests
{
    public class ResturantCreateCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_ValidCommand_ReturnsCreatedResturantId()
        {
            // Arrange
            var logger = new Mock<ILogger<ResturantCreateCommandHandler>>();

            var resturant = new Domain.Entities.Resturant();
            var command = new ResturantCreateCommand();
            var mapper = new Mock<IMapper>();
            mapper.Setup(m=>m.Map<Domain.Entities.Resturant>(command)).Returns(resturant);
          
            var resturantRepository = new Mock<IResturantRepository>();
            resturantRepository.Setup(r => r.AddAsync(resturant))
                .ReturnsAsync(1);

            var userContext = new Mock<IUserContext>();
            var currentUser = new CurrentUser("owner-id", "user@gmail.com", [UserRoles.Owner]);
            userContext.Setup(uc => uc.GetCurrentUser())
                .Returns(currentUser);

            var handler = new ResturantCreateCommandHandler(mapper.Object, logger.Object, 
                resturantRepository.Object, userContext.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            resturant.OwnerId.Should().Be("owner-id");
            result.Should().Be(1);
            resturantRepository.Verify(r => r.AddAsync(resturant), Times.Once);
        }
    }
}