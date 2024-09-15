using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Helpers;
using OnionDemo.Domain.Entity;


namespace OnionDemo.Application.Command
{
    public class AccommodationCommand : IAccommodationCommand
    {
        private readonly IAccommodationRepository _repository;
        private readonly IUnitOfWork _uow;

        public AccommodationCommand(IUnitOfWork uow, IAccommodationRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }
       
        void IAccommodationCommand.CreateAccommodation(CreateAccommodationDto accommodationDto)
        {
            try
            {
                _uow.BeginTransaction();

                // Do
                var accommodation = Accommodation.Create(accommodationDto.Name, accommodationDto.Location, accommodationDto.HostId);

                // Save
                _repository.AddAccommodation(accommodation);

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

        void IAccommodationCommand.DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto)
        {
            try
            {
                _uow.BeginTransaction();

                // Load
                var accommodation = _repository.GetAccommodation(deleteAccommodationDto.Id);
                // Do
                if (accommodation == null) throw new Exception("Accommodation not found");
                _repository.DeleteAccommodation(accommodation.Id);
                // Commit
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

        void IAccommodationCommand.UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto)
        {
            try
            {
                _uow.BeginTransaction();
                
                // Load
                var accommodation = _repository.GetAccommodation(updateAccommodationDto.Id);
                
                // Do
                accommodation.Update(updateAccommodationDto.Name, updateAccommodationDto.Location, updateAccommodationDto.HostId);

                // Save
                _repository.UpdateAccommodation(accommodation, updateAccommodationDto.RowVersion);
                _uow.Commit();
            }
            catch (Exception )
            {
                try
                {
                    _uow.Rollback();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Rollback failed: {ex.Message}");
                }
                throw;
            }
        }
    }
}
