﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Command.DeleteDish
{
    public class DeleteDishForRestaurantCommand(int id): IRequest
    {
        public int Id { get; } = id;
    }
}
