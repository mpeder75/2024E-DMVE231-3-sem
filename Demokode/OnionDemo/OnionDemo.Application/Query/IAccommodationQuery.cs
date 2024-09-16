using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Application.Query
{
    public interface IAccommodationQuery
    {
        // Get accommodation by id
        AccommodationDto GetAccommodation(int id);
        // Get all accommodations
        IEnumerable<AccommodationDto> GetAccommodations();
        // Get all accommodations by host
        IEnumerable<AccommodationDto> GetAccommodationsByHost(int hostId);
    }
}
