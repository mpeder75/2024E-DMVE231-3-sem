using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.DomainServices
{
    public interface IAccommodationDomainService
    {
        void ValidateAccommodation(Accommodation accommodation);
        bool CheckForConflicts(Accommodation accommodation);
    }
}
