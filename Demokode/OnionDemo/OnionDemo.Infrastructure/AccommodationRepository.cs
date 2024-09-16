using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using OnionDemo.Application;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly BookMyHomeContext _db;

        public AccommodationRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
        {
            // Do
            _db.Accommodations.Add(accommodation);
            // Save
            _db.SaveChanges();
        }

        void IAccommodationRepository.DeleteAccommodation(int id)
        {
            // Load
            var accommodation = _db.Accommodations.Find(id);
            // Do
            if(accommodation == null) throw new Exception("Ingen Accommodation fundet");

            _db.Accommodations.Remove(accommodation);
            // Save
            _db.SaveChanges();
        }

        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return _db.Accommodations.Include(a => a.Bookings).SingleOrDefault(a => a.Id == id);
        }

        IEnumerable<Accommodation> IAccommodationRepository.GetAccommodations()
        {
            return _db.Accommodations.Include(a => a.Bookings).AsNoTracking().ToList();

        }

        IEnumerable<Accommodation> IAccommodationRepository.GetAccommodationsByHost(int hostId)
        {
            return _db.Accommodations.Include(a => a.Bookings).AsNoTracking().Where(x => x.HostId == hostId).ToList();

        }

        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _db.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _db.SaveChanges();
        }
    }
}
