using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Helpers;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class AccommodationCommand : IAccommodationCommand
{
    private readonly IHostRepository _hostRepository;
    private readonly IAccommodationRepository _repository;
    private readonly IUnitOfWork _uow;

    public AccommodationCommand(IUnitOfWork uow, IAccommodationRepository repository, IHostRepository hostRepository)
    {
        _uow = uow;
        _repository = repository;
        _hostRepository = hostRepository;
    }

    void IAccommodationCommand.Create(CreateAccommodationDto createAccommodationDto)
    {
        var host = _hostRepository.Get(createAccommodationDto.HostId);
        var accommodation = Accommodation.CreateAccommodation(host);
        _repository.Add(accommodation);
    }

    void IAccommodationCommand.Delete(DeleteAccommodationDto deleteAccommodationDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.Update(UpdateAccommodationDto updateAccommodationDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.CreateBooking(CreateBookingDto bookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            var accommodation = _repository.GetAccommodation(bookingDto.AccommodationId);
            var guest = _repository.GetGuest(bookingDto.GuestId);
            // Do
            accommodation.CreateBooking(bookingDto.StartDate, bookingDto.EndDate, guest);
            // Save
            _repository.AddBooking(accommodation);
            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }
            throw;
        }
    }

    void IAccommodationCommand.UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        try
        {
            _uow.BeginTransaction();
            // Load
            var accommodation = _repository.GetAccommodation(updateBookingDto.AccommodationId);
            // Do
            var booking = accommodation.UpdateBooking(updateBookingDto.Id, updateBookingDto.StartDate,
                updateBookingDto.EndDate);
            // Save
            _repository.UpdateBooking(booking, updateBookingDto.RowVersion);
            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception ex)
            {
                throw new Exception($"Rollback failed: {ex.Message}", e);
            }
            throw;
        }
    }

    void IAccommodationCommand.DeleteBooking(DeleteBookingDto deleteBookingDto)
    {
        throw new NotImplementedException();
    }

    void IAccommodationCommand.CreateReview(CreateReviewDto createReviewDto)
    {
        try
        {
            // Begin transaction/uow
            _uow.BeginTransaction();

            // Load Accommodation
            var accommodation = _repository.GetAccommodation(createReviewDto.AccommodationId);
            // Load Guest
            var guest = _repository.GetGuest(createReviewDto.GuestId);
            // Load Booking
            var booking = _repository.GetBooking(createReviewDto.BookingId);

            // Do - Create et review for en Accommodation  
            accommodation.CreateReview(createReviewDto.Content, createReviewDto.Rating, guest, booking);

            // Commit transaction/uow
            _uow.Commit();
        }
        catch (Exception e)
        {
            try
            {
                _uow.Rollback();
            }
            catch (Exception exception)
            {
                throw new Exception($"Rollback failed: {e.Message}", e);
            }
            throw;
        }
    }
}