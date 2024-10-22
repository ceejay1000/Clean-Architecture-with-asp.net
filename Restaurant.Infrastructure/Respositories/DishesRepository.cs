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
    public class DishesRepository(RestaurantDbContext restaurantDbContext) : IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            restaurantDbContext.Dishes.Add(entity);
            await restaurantDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(IEnumerable<Dish> dishes)
        {
            if (dishes != null || dishes!.Any())
                restaurantDbContext.RemoveRange(dishes!);

            await restaurantDbContext.SaveChangesAsync(); 
        }
    }
}
