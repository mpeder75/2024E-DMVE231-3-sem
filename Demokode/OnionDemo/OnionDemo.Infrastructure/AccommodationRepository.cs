using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly BookMyHomeContext _db;

    public AccommodationRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    public void Add(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
        _db.SaveChanges();
    }

    void IAccommodationRepository.AddBooking(Accommodation accommodation)
    {
        _db.Bookings.Add(accommodation.Bookings.Last());
        _db.SaveChanges();
    }

    void IAccommodationRepository.AddReview(Review review)
    {
       _db.Reviews.Add(review);
       _db.SaveChanges();
    }

    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations
            .Include(a => a.Bookings)
            .Single(a => a.Id == id);
    }

    Booking IAccommodationRepository.GetBooking(int id)
    {
        return _db.Bookings.Find(id);
    }

    Guest IAccommodationRepository.GetGuest(int id)
    {
        return _db.Guests.Find(id);
    }

    IEnumerable<Review> IAccommodationRepository.GetReviewsForAccommodation(int accommodationId)
    {
        return _db.Reviews
            .Include(r => r.Guest)
            .Include(r => r.Booking)
            .Where(r => r.Accommodation.Id == accommodationId)
            .ToList();
    }

    void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
    {
        _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
        _db.SaveChanges();
    }
}