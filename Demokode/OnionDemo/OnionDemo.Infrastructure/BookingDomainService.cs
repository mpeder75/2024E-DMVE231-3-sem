using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;


namespace OnionDemo.Infrastructure
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly BookMyHomeContext _db;
        public BookingDomainService(BookMyHomeContext db)
        {
            _db = db;
        }
        public IEnumerable<Booking> GetOtherBookings(Booking booking)
        {
            //var result = _db.Bookings.ToList().Except(new List<Booking>(new[] { booking }));
            var result = _db.Bookings
                .Where(a => a.Id != booking.Id)
                .ToList();
            return result;
        }
    }
}
