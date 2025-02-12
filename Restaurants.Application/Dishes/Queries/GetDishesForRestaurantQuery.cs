﻿using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries
{
    public class GetDishesForRestaurantQuery(int restaurantId): IRequest<IEnumerable<DishDto>>
    {
        public int RestaurantId { get; set; } = restaurantId;
    }
}
