using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurants
{
    public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting restaurant with ID : {request.Id}");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync( request.Id );

            //if (restaurant is null)
            //{
            //    return false;
            //}


            if (restaurant is null)
                throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            await restaurantsRepository.DeleteAsync(restaurant);
            return true;
        }
    }
}
