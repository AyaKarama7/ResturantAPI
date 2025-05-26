using FluentValidation;
using FluentValidation.Validators;

namespace Resturant.Application.Resturants.Commands.ResturantCreate
{
    public class ResturantCreateCommandValidator : AbstractValidator<ResturantCreateCommand>
    {
        private List<string> ValidCategories = new List<string>
        {
            "Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese", "Mediterranean"
        };
        public ResturantCreateCommandValidator()
        {
            RuleFor(dto => dto.Name)
                .Length(3, 100)
                .WithMessage("Name must be between 3 and 100 characters.");
            RuleFor(dto => dto.Description)
                .NotEmpty()
                .WithMessage("Description cannot be empty.");
            RuleFor(dto => dto.Category)
                .Must(category => ValidCategories.Contains(category))
                .WithMessage($"Category must be one of the following: {string.Join(", ", ValidCategories)}.");
            //.Custom((category, context) =>
            //{
            //    if (!ValidCategories.Contains(category))
            //    {
            //        context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", ValidCategories)}.");
            //    }
            //});
            RuleFor(dto => dto.HasDelivery)
                .NotNull()
                .WithMessage("HasDelivery must be specified.");
            RuleFor(dto => dto.Email)
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("Invalid email address format.");
            RuleFor(dto => dto.ContactNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Invalid phone number format.");
            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("Postal code must be in the format XX-XXX.");


        }
    }
}
