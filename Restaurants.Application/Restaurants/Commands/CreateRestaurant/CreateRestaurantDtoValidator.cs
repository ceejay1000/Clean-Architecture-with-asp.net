

using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> validCategories = ["mexican"];
        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().WithMessage("Name is required").Length(3, 100);

            RuleFor(dto => dto.Description).NotEmpty().WithMessage("Description is required");

            //RuleFor(dto => dto.Category).Custom((value, context) =>
            //{
            //    var isValidCategory = validCategories.Contains(value);
            //    if (!isValidCategory)
            //    {
            //        context.AddFailure("Category", "Invalid category. Please select a valid category");
            //    }
            //}).NotEmpty().WithMessage("Category is required").Length(3, 100);   

            RuleFor(dto => dto.Category).Must(category =>
            {
                return validCategories.Contains(category);
            }).WithMessage("Invalid category. Please select a valid category").NotEmpty().WithMessage("Category is required").Length(3, 100);

            RuleFor(dto => dto.ContactEmail)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Please provide a valid email");

            RuleFor(dto => dto.PostalCode)
                .Matches(@"^\d{2}-\d{3}$")
                .WithMessage("Please provide a valid postal code (xx-xx)");
        }
    }
}
