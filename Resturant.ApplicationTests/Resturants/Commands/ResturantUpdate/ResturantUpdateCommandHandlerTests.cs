using Xunit;
using Resturant.Application.Resturants.Commands.ResturantUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using FluentAssertions;

namespace Resturant.Application.Resturants.Commands.ResturantUpdate.Tests
{
    public class ResturantUpdateCommandHandlerTests
    {
        [Fact()]
        public async Task HandleTest_VaildCommand_ReturnsUpdatedResturantId()
        {
            // Arrange
            var logger = new Mock<ILogger<ResturantUpdateCommandHandler>>();
            var mapper = new Mock<IMapper>();
            var resturant = new Domain.Entities.Resturant();
            var command = new ResturantUpdateCommand();
            mapper.Setup(m => m.Map<Domain.Entities.Resturant>(command)).Returns(resturant);
            var resturantRepository = new Mock<Domain.IRepositories.IResturantRepository>();
            resturantRepository.Setup(r => r.GetByIdAsync(command.Id))
                .ReturnsAsync(resturant);
            resturantRepository.Setup(r => r.UpdateAsync(resturant))
                .ReturnsAsync(1);
            var handler = new ResturantUpdateCommandHandler(mapper.Object, logger.Object,
                resturantRepository.Object);
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            result.Should().Be(1);
            resturantRepository.Verify(r => r.GetByIdAsync(command.Id), Times.Once);
            resturantRepository.Verify(r => r.UpdateAsync(resturant), Times.Once);
            mapper.Verify(m => m.Map(command, resturant), Times.Once);

        }
    }
}