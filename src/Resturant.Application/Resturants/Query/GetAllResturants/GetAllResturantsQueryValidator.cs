using FluentValidation;
using Resturant.Application.Resturants.DTOs;

namespace Resturant.Application.Resturants.Query.GetAllResturants
{
    public class GetAllResturantsQueryValidator:AbstractValidator<GetAllResturantsQuery>
    {
        private int[] AllowedPageSize = [10, 20, 50, 100];
        private string[] AllowedSortBy = 
            [
            nameof(ResturantDisplayDTO.Name),
            nameof(ResturantDisplayDTO.Category),
            nameof(ResturantDisplayDTO.City)
        ];
        public GetAllResturantsQueryValidator()
        {
            RuleFor(x=>x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0");
            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size must be greater than 0")
                .Must(x => AllowedPageSize.Contains(x))
                .WithMessage($"Page size must be one of the following values: {string.Join(", ", AllowedPageSize)}");
            RuleFor(x => x.SortBy)
                .Must(x => string.IsNullOrEmpty(x) || AllowedSortBy.Contains(x))
                .WithMessage($"SortBy must be one of the following values: {string.Join(", ", AllowedSortBy)}");
        }

    }
}
