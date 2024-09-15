using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command
{
    public interface IAccommodationCommand
    {
        void CreateAccommodation(CreateAccommodationDto accommodationDto);
        void UpdateAccommodation(UpdateAccommodationDto updateAccommodationDto);
        void DeleteAccommodation(DeleteAccommodationDto deleteAccommodationDto);
    }
}
