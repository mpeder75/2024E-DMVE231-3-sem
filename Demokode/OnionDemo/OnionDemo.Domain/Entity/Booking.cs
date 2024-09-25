﻿namespace OnionDemo.Domain.Entity;

public class Booking : DomainEntity
{
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    // Navigation property - En Booking kan have EN Accommodation
    public Accommodation Accommodation { get; set; }

    protected Booking()
    {
    }

    private Booking(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> exsistingBookings, Accommodation accommodation)
    {
        StartDate = startDate;
        EndDate = endDate;
        Accommodation = accommodation;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(exsistingBookings);
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

    protected void AssureNoOverlapping(IEnumerable<Booking> exsistingBookings)
    {
        var otherBookings = exsistingBookings.Except(new[] { this });
        if (otherBookings.Any(other =>
                (EndDate <= other.EndDate && EndDate >= other.StartDate) ||
                (StartDate >= other.StartDate && StartDate <= other.EndDate) ||
                (StartDate <= other.StartDate && EndDate >= other.EndDate)))
            throw new Exception("Booking overlapper med en anden booking");
    }

    /// <summary>
    ///     Booking factory method
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="exsistingBookings"></param>
    /// <returns></returns>
    public static Booking Create(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> exsistingBookings)
    {
        return new Booking(startDate, endDate, exsistingBookings);
    }

    public void Update(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> exsistingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(exsistingBookings);
    }
}