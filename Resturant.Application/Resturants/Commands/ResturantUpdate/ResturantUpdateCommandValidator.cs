using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Application.Resturants.Commands.ResturantUpdate
{
    public class ResturantUpdateCommandValidator : AbstractValidator<ResturantUpdateCommand>
    {
        private List<string> ValidCategories = new List<string>
        {
            "Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese", "Mediterranean"
        };
        public ResturantUpdateCommandValidator()
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

        }
    }
}
