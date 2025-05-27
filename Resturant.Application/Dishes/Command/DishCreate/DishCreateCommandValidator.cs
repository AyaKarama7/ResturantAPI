using FluentValidation;


namespace Resturant.Application.Dishes.Command.DishCreate
{
    public class DishCreateCommandValidator:AbstractValidator<DishCreateCommand>
    {
        public DishCreateCommandValidator()
        {
            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price can't be negative");
            RuleFor(dto=>dto.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price can't be negative");
        }
    }
}
