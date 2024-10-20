using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Respositories
{
    internal class RestaurantRepository(RestaurantDbContext restaurantDbContext) : IRestaurantsRepository
    {
        public async Task<int> Create(Restaurant restaurant)
        {
           restaurantDbContext.Restaurants.Add(restaurant); 
           await restaurantDbContext.SaveChangesAsync();
           return restaurant.Id;
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
           var restaurants = await restaurantDbContext.Restaurants.ToListAsync();
           return restaurants;
        }

        public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await restaurantDbContext.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
            return restaurant;
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            restaurantDbContext.Remove(restaurant);
            await restaurantDbContext.SaveChangesAsync(); 
        }

        public async Task SaveChanges()
        {
            await restaurantDbContext.SaveChangesAsync();
        }
    }
}
