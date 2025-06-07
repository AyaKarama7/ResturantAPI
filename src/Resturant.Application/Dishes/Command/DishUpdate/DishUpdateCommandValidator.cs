using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Dishes.Command.DishUpdate
{
    public class DishUpdateCommandValidator:AbstractValidator<DishUpdateCommand>
    {
        public DishUpdateCommandValidator()
        {
            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price can't be negative");
            RuleFor(dto => dto.KiloCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price can't be negative");
        }
    }
}
