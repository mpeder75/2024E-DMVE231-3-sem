using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Query.QueryDto
{
    public class AccommodationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
