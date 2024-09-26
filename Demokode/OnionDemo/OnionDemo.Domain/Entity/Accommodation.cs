namespace OnionDemo.Domain.Entity;

public class Accommodation : DomainEntity
{
    // Navigation property - En Accommodation kan have MANGE Bookings
    private readonly List<Booking> _bookings = new();
    // Navigation property - En Accommodation kan have MANGE Reviews
    private readonly List<Review> _reviews = new();
    // Navigation property - En Accommodation kan have EN Host
    public Host Host { get; protected set; }

    /// <summary>
    ///     Using IReadOnlyCollection
    ///     <T>
    ///         is a good practice when you want to expose a collection that should not be modified
    ///         directly by consumers of the class. This ensures that the internal state of the class is protected and can only
    ///         be modified through controlled methods.
    ///         This ensures that the _bookings list can only be modified internally within the Accommodation class,
    ///         and external consumers can only read from it.
    /// </summary>
    public IReadOnlyCollection<Booking> Bookings => _bookings;

    public IReadOnlyCollection<Review> Reviews => _reviews;

    protected Accommodation()
    {
    }

    private Accommodation(Host host)
    {
        Host = host;
    }

    // CreateAccommodation
    public static Accommodation CreateAccommodation(Host host)
    {
        return new Accommodation(host);
    }

    // CreateBooking
    public void CreateBooking(DateOnly startDate, DateOnly endDate, Guest guest)
    {
        var booking = Booking.Create(startDate, endDate, Bookings, this, guest);
        _bookings.Add(booking);
    }

    // CreateReview
    public void CreateReview(string content, int rating, Guest guest, Booking booking)
    {
        if (booking.StartDate >= DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException("Review kan kun oprettes efter en booking er påbegyndt");
        }

        // Review oprettes
        var review = Review.Create(content, rating, this, guest, booking);
        // Review tilføjes til reviews collection
        _reviews.Add(review);
        // Review tilføjes til en guest review collection
        guest.Reviews.Add(review);
    }

    // UpdateBooking
    public Booking UpdateBooking(int bookingId, DateOnly startDate, DateOnly endDate)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null) throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, Bookings);
        return booking;
    }
}