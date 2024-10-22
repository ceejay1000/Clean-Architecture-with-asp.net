using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Command.DeleteDish
{
    internal class DeleteDishForRestaurantCommandHandler(ILogger<DeleteDishForRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository) : IRequestHandler<DeleteDishForRestaurantCommand>
    {
        public async Task Handle(DeleteDishForRestaurantCommand request, CancellationToken cancellationToken)
        {

            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);

            if (restaurant == null) throw new DirectoryNotFoundException("No restaurant found");
            
            await dishesRepository.Delete(restaurant.Dishes);
        }
    }
}
