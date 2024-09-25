namespace OnionDemo.Domain.Entity;

public class Review : DomainEntity
{
    public string Content { get; set; }
    public int Rating { get; set; }

    // Navigation property - En Review kan have EN Accommodation
    public Accommodation Accommodation { get; private set; }
    // Navigation property - En Review kan have EN Guest
    public Guest Guest { get; private set; }
    // Navigation property - En Review kan have EN Booking
    public Booking Booking { get; private set; }

    
    // private constructor til Factory CreateAccommodation
    private Review()
    {
    }

    private Review(string content, int rating, Accommodation accommodation, Guest guest, Booking booking)
    {
        Content = content;
        Rating = rating;
        Accommodation = accommodation;
        Guest = guest;
        Booking = booking;
    }

    public static Review Create(string content, int rating, Accommodation accommodation, Guest guest, Booking booking)
    {
        return new Review(content, rating, accommodation, guest, booking);
    }
}