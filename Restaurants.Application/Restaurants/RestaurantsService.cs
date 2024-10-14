using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants
{
    internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
    {
        public async Task<int> Create(CreateRestaurantDto createRestaurantDto)
        {
            logger.LogInformation("Creating a new restaurant");

            var restaurant = mapper.Map<Restaurant>(createRestaurantDto);

            int id = await restaurantsRepository.Create(restaurant);

            return id;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            var restaurants = await restaurantsRepository.GetAllAsync();
            logger.LogInformation("Getting all restaurants");
            var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return restaurantsDto;
        }

        public async Task<RestaurantDto?> GetRestaurantById(int id)
        {
            logger.LogInformation($"Getting restaurant with id {id} from db");
            var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(id);
            var restaurantsDto = mapper.Map<RestaurantDto>(restaurant);

            return restaurantsDto;
        }
    }
}
