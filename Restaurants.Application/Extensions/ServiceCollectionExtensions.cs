using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplication(this IServiceCollection services)
        {
           var applicationAssembley = typeof(ServiceCollectionExtensions).Assembly;
          // services.AddScoped<IRestaurantsService, RestaurantsService>();
           services.AddAutoMapper(applicationAssembley);
           services.AddValidatorsFromAssembly(applicationAssembley).AddFluentValidationAutoValidation();
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembley));
          
        }
    }
}
