using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IAccommodationRepository
    {
        Accommodation GetAccommodation(int id);
        void AddBooking(Accommodation accommodation);
        void UpdateBooking(Booking booking, byte[] rowversion);
        void Add(Accommodation accommodation);

        Guest GetGuest(int id);
        Booking GetBooking(int id);
        IEnumerable<Review> GetReviewsForAccommodation(int accommodationId);
        void AddReview(Review review);
    }
}
