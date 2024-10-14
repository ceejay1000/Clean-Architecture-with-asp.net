
namespace Restaurants.Domain.Entities
{
    public class Address
    {

        public string? Street { get; set; }

        public string City { get; set; } = default!;

        public string? PostalCode { get; set; }
    }
}
