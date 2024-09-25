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
        AccommodationDto GetAccommodationById(int accommodationId);
        IEnumerable<AccommodationDto> GetAccommodations();
    }
}
