using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, int>
    {
        public Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
