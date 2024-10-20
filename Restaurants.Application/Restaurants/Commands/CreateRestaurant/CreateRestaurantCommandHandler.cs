using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        private readonly IMapper mapper;
        private ILogger logger;
        private readonly IRestaurantsRepository restaurantsRepository;

        public CreateRestaurantCommandHandler(IMapper mapper, ILogger<CreateRestaurantCommandHandler> logger, IRestaurantsRepository restaurants)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.restaurantsRepository = restaurants;
        }
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {

            logger.LogInformation("Creating a new restaurant {@Restaurant}", request);
            var restaurant = mapper.Map<Restaurant>(request);
            int id = await restaurantsRepository.Create(restaurant);

            return id;
        }
    }
}
