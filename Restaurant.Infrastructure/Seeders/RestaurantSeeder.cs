using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    dbContext.Restaurants.AddRange(GetRestaurants());
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            // Create some sample dishes
            var dish1 = new Dish { Name = "Pizza Margherita", Description = "Classic Italian pizza", Price = 10.99M };
            var dish2 = new Dish { Name = "Caesar Salad", Description = "Fresh salad with croutons", Price = 7.99M };
            var dish3 = new Dish { Name = "Cheeseburger", Description = "Beef burger with cheddar cheese", Price = 8.99M };

            // Create sample addresses
            var address1 = new Address { Street = "123 Main St", City = "New York", PostalCode = "10001" };
            var address2 = new Address { Street = "456 Elm St", City = "Los Angeles", PostalCode = "90001" };

            // Create some sample restaurants with dishes and addresses
            var restaurant1 = new Restaurant
            {
            
                Name = "Italiano Bistro",
                Description = "Authentic Italian cuisine",
                Category = "Italian",
                HasDelivery = true,
                ContactEmail = "info@italianobistro.com",
                ContactNumber = "123-456-7890",
                Address = address1,
                Dishes = new List<Dish> { dish1, dish2 }
            };

            var restaurant2 = new Restaurant
            {
                
                Name = "Burger Haven",
                Description = "The best burgers in town",
                Category = "Fast Food",
                HasDelivery = false,
                ContactEmail = "contact@burgerhaven.com",
                ContactNumber = "987-654-3210",
                Address = address2,
                Dishes = new List<Dish> { dish3 }
            };

            // Create a list of restaurants
            return new List<Restaurant> { restaurant1, restaurant2 };
        }
    }
}
