using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Command.CommandDto
{
    public class UpdateAccommodationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int HostId { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
