using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            var accommodation = _db.Accommodations
                .Include(a => a.Bookings)
                .SingleOrDefault(a => a.Id == id);

            return new AccommodationDto
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Location = accommodation.Location,
                HostId = accommodation.HostId,
                Bookings = accommodation.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    AccommodationId = b.AccommodationId,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate
                }).ToList()
            };
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodations()
        {
            return _db.Accommodations
                .Include(a => a.Bookings)
                .Select(a => new AccommodationDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Location = a.Location,
                    HostId = a.HostId,
                    Bookings = a.Bookings.Select(b => new BookingDto
                    {
                        Id = b.Id,
                        AccommodationId = b.AccommodationId,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate
                    }).ToList()
                }).ToList();
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodationsByHost(int hostId)
        {
            return _db.Accommodations
                .Include(a => a.Bookings)
                .Where(a => a.HostId == hostId)
                .Select(a => new AccommodationDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Location = a.Location,
                    HostId = a.HostId,
                    Bookings = a.Bookings.Select(b => new BookingDto
                    {
                        Id = b.Id,
                        AccommodationId = b.AccommodationId,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate
                    }).ToList()
                }).ToList();
        }
    }
}
