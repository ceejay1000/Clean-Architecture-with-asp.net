using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Exceptions
{
    public class NotFoundException(string resourceType, string? resourceIdentifier = default): Exception($"{resourceType} with id: {resourceIdentifier} does not exist")
    {
    }
}
