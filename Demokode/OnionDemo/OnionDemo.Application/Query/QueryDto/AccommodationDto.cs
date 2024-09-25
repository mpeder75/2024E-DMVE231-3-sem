// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace OnionDemo.Application.Query.QueryDto;

public class AccommodationDto
{
    public int Id { protected get; set; }

    public IEnumerable<BookingDto>? Bookings { get; set; }
    public IEnumerable<ReviewDto>? Reviews { get; set; }
    public int HostId { get; set; }
}