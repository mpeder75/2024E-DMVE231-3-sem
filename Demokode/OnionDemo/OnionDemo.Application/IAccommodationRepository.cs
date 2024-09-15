using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IAccommodationRepository
    {
        // Command - kommer fra IAccommodationCommand
        void AddAccommodation(Accommodation accommodation);
        void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion);
        void DeleteAccommodation(int id);
        //Query - kommer fra IAccommodationQuery
        Accommodation GetAccommodation(int id);
        IEnumerable<Accommodation> GetAccommodations();
        IEnumerable<Accommodation> GetAccommodationsByHost(int hostId);
    }
}
