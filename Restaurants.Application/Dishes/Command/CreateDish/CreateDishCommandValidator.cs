using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Command.CreateDish
{
    public class CreateDishCommandValidator: AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negative");
            
            RuleFor(dish => dish.Kilocalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Kilocalories must be a non-negative");
        }

    }
}
