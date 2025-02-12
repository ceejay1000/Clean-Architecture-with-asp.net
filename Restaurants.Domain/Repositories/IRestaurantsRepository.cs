﻿using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
    public interface IRestaurantsRepository
    {
        Task<IEnumerable<Restaurant>> GetAllAsync();

        Task<Restaurant?> GetRestaurantByIdAsync(int id);

        Task<int> Create(Restaurant restaurant);
        Task SaveChanges();
        Task DeleteAsync(Restaurant restaurant);
    }
}
