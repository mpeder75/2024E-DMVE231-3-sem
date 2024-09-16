using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Infrastructure.Queries
{
    public class AccommodationQuery : IAccommodationQuery
    {
        private readonly BookMyHomeContext _db;

        public AccommodationQuery(BookMyHomeContext db )
        {
            _db = db;
        }


        AccommodationDto IAccommodationQuery.GetAccommodation(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodations()
        {
            throw new NotImplementedException();
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodationsByHost(int hostId)
        {
            throw new NotImplementedException();
        }
    }
}
