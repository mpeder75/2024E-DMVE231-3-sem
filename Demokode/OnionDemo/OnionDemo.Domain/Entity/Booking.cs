using System.ComponentModel.DataAnnotations;
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity;


public class Booking : DomainEntity
{
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    public int AccommodationId { get; set; }

    protected Booking(){}

    private Booking(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService, int accommodationId)
    {
        StartDate = startDate;
        EndDate = endDate;
        AccommodationId = accommodationId;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(bookingDomainService.GetOtherBookings(this));
    }

    protected void AssureStartDateBeforeEndDate()
    {
        if (!(StartDate < EndDate)) throw new ArgumentException("StartDato skal være før EndDato");
    }
    protected void AssureBookingSkalVæreIFremtiden(DateOnly now)
    {
        // Booking skal være i fremtiden
        if (StartDate <= now)
            throw new ArgumentException("Booking skal være i fremtiden");
    }
    protected void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        if (otherBookings.Any(other =>
                (EndDate <= other.EndDate && EndDate >= other.StartDate) ||
                (StartDate >= other.StartDate && StartDate <= other.EndDate) ||
                (StartDate <= other.StartDate && EndDate >= other.EndDate)))
            throw new Exception("Booking overlapper med en anden booking");
    }
    
    public static Booking Create(DateOnly startDate, DateOnly endDate, IBookingDomainService bookingDomainService, int accommodation)
    {
        return new Booking(startDate, endDate, bookingDomainService, accommodation);
    }

    public void Update(DateOnly startDate, DateOnly endDate, IBookingDomainService domainService)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(domainService.GetOtherBookings(this));
    }
}