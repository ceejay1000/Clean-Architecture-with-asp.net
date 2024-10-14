﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class CreateRestaurantDto
    {
    //    [StringLength(100, MinimumLength = 6)]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

    //    [Required(ErrorMessage = "Insert a valid category")]
        public string Category { get; set; } = default!;

        public bool HasDelivery { get; set; }

      //  [EmailAddress(ErrorMessage = "Please provide a valid email")]
        public string? ContactEmail { get; set; }

      //  [Phone(ErrorMessage = "Please provide a valid phone number")]
        public string? ContactNumber { get; set; }

        public string? Street { get; set; }

        public string City { get; set; } = default!;

     //   [RegularExpression(@"^\d{2}-\d{3}", ErrorMessage = "Please provide a valid postal code")]
        public string? PostalCode { get; set; }
    }
}
