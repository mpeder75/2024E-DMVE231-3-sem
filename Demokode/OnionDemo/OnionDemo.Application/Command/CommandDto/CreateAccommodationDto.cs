using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Command.CommandDto
{
    public class CreateAccommodationDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int HostId { get; set; }
    }
}
