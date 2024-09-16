using OnionDemo.Application.Query.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Query
{
    public class AccommodationQueryHandler : IAccommodationQuery
    {
        private readonly IAccommodationRepository _accommodationRepository;

        public AccommodationQueryHandler(IAccommodationRepository accommodationRepository)
        {
            _accommodationRepository = accommodationRepository;
        }
        AccommodationDto IAccommodationQuery.GetAccommodation(int id)
        {
            var accommodation = _accommodationRepository.GetAccommodation(id);
            if (accommodation == null) return null;

            return new AccommodationDto
            {
                Id = accommodation.Id,
                Name = accommodation.Name,
                Location = accommodation.Location,
                HostId = accommodation.HostId,
                Bookings = accommodation.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    AccommodationId = b.AccommodationId
                }).ToList()
            };
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodations()
        {
            var accommodations = _accommodationRepository.GetAccommodations();
            return accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id,
                Name = a.Name,
                Location = a.Location,
                HostId = a.HostId,
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    AccommodationId = b.AccommodationId
                }).ToList()
            }).ToList();
        }

        IEnumerable<AccommodationDto> IAccommodationQuery.GetAccommodationsByHost(int hostId)
        {
            var accommodations = _accommodationRepository.GetAccommodationsByHost(hostId);
            return accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id,
                Name = a.Name,
                Location = a.Location,
                HostId = a.HostId,
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    AccommodationId = b.AccommodationId
                }).ToList()
            }).ToList();
        }
    }

}
