using Xunit;
using FluentValidation;
using FluentValidation.TestHelper;
namespace Resturant.Application.Resturants.Commands.ResturantCreate.Tests
{
    public class ResturantCreateCommandValidatorTests
    {
        [Fact()]
        public void ResturantCreateCommandValidatorTest_ValidCommand_ShouldnotReturnValidationErrors()
        {
            //arrange
            var command = new ResturantCreateCommand()
            {
                Name = "Test Restaurant",
                Description = "A test restaurant for validation.",
                Category = "Italian",
                HasDelivery = true,
                PostalCode = "12-345",
                ContactNumber = "+1234567890",
                Email = "test@gmail.com",
            };
            var validator = new ResturantCreateCommandValidator();
            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldNotHaveAnyValidationErrors();

        }
        [Fact()]
        public void ResturantCreateCommandValidatorTest_InvalidCommand_ShouldReturnValidationError()
        {
            //arrange
            var command = new ResturantCreateCommand()
            {
                Name = "Te",
                Description = "",
                Category = "Egyptian",
                HasDelivery = true,
                PostalCode = "12345",
                ContactNumber = "",
                Email = "invalid-email-format"
            };
            var validator = new ResturantCreateCommandValidator();
            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldHaveValidationErrorFor(dto => dto.Name)
                  .WithErrorMessage("Name must be between 3 and 100 characters.");
            result.ShouldHaveValidationErrorFor(dto => dto.Description)
                    .WithErrorMessage("Description cannot be empty.");
            result.ShouldHaveValidationErrorFor(dto => dto.Category)
                    .WithErrorMessage("Category must be one of the following: Italian, Chinese, Indian, Mexican, American, French, Japanese, Mediterranean.");
            result.ShouldHaveValidationErrorFor(dto => dto.PostalCode)
                    .WithErrorMessage("Postal code must be in the format XX-XXX.");
            result.ShouldHaveValidationErrorFor(dto => dto.ContactNumber)
                    .WithErrorMessage("Invalid phone number format.");
            result.ShouldHaveValidationErrorFor(dto => dto.Email)
                    .WithErrorMessage("Invalid email address format.");

        }
        [Theory()]
        [InlineData("Italian")]
        [InlineData("Chinese")]
        [InlineData("Indian")]
        [InlineData("Mexican")]
        [InlineData("American")]
        [InlineData("French")]
        [InlineData("Japanese")]
        [InlineData("Mediterranean")]
        public void ResturantCreateCommandValidatorTest_ValidCategory_ShouldnotReturnValidationErrorsForCategoy(string category)
        {
            var validator = new ResturantCreateCommandValidator();
            var command = new ResturantCreateCommand() { Category = category };
            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldNotHaveValidationErrorFor(dto => dto.Category);
        }
        [Theory()]
        [InlineData("21065")]
        [InlineData("123-456")]
        [InlineData("123-45")]
        [InlineData("12-3456")]
        [InlineData("12-34a")]
        [InlineData("12-34")]
        public void ResturantCreateCommandValidatorTest_InvalidPostalCode_ShouldReturnValidationError(string postalCode)
        {
            var validator = new ResturantCreateCommandValidator();
            var command = new ResturantCreateCommand() { PostalCode = postalCode };
            //act
            var result = validator.TestValidate(command);
            //assert
            result.ShouldHaveValidationErrorFor(dto => dto.PostalCode)
                  .WithErrorMessage("Postal code must be in the format XX-XXX.");
        }
    }
}