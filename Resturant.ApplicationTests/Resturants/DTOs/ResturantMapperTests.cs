using AutoMapper;
using FluentAssertions;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Application.Resturants.Commands.ResturantUpdate;
using Xunit;
namespace Resturant.Application.Resturants.DTOs.Tests
{
    public class ResturantMapperTests
    {
        private readonly IMapper mapper;
        public ResturantMapperTests()
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile<ResturantMapper>());
            mapper = config.CreateMapper();
        }
        [Fact()]
        public void CreateMap_FromResturantToResturantDto_MapsCorrectly()
        {
            // Arrange
            var resturant = new Domain.Entities.Resturant
            {
                Id = 1,
                Name = "Test Resturant",
                Address = new Domain.Entities.Address
                {
                    Street = "123 Test St",
                    City = "Test City",
                    PostalCode = "12345"
                }
            };
            // Act
            var resturantDto = mapper.Map<ResturantDisplayDTO>(resturant);
            // Assert
            resturantDto.Should().NotBeNull();
            resturantDto.Id.Should().Be(resturant.Id);
            resturantDto.Name.Should().Be(resturant.Name);
            resturantDto.Street.Should().Be(resturant.Address?.Street);
            resturantDto.City.Should().Be(resturant.Address?.City);
            resturantDto.PostalCode.Should().Be(resturant.Address?.PostalCode);
        }
        [Fact()]
        public void CreateMap_FromResturantCreateCommandToResturant_MapsCorrectly()
        {
            // Arrange
            var command = new ResturantCreateCommand
            {
                Name = "New Resturant",
                Street = "456 New St",
                City = "New City",
                PostalCode = "67890"
            };
            // Act
            var resturant = mapper.Map<Domain.Entities.Resturant>(command);
            // Assert
            resturant.Should().NotBeNull();
            resturant.Name.Should().Be(command.Name);
            resturant.Address.Should().NotBeNull();
            resturant.Address.Street.Should().Be(command.Street);
            resturant.Address.City.Should().Be(command.City);
            resturant.Address.PostalCode.Should().Be(command.PostalCode);
        }
        [Fact()]
        public void CreateMap_FromResturantUpdateCommandToResturant_MapsCorrectly()
        {
            // Arrange
            var command = new ResturantUpdateCommand
            {
                Id = 1,
                Name = "Updated Resturant",
                Description = "Updated Description",
                Category = "Indian",
            };
            // Act
            var resturant = mapper.Map<Domain.Entities.Resturant>(command);
            // Assert
            resturant.Should().NotBeNull();
            resturant.Id.Should().Be(command.Id);
            resturant.Name.Should().Be(command.Name);
            resturant.Description.Should().Be(command.Description);
            resturant.Category.Should().Be(command.Category);
        }
    }
}