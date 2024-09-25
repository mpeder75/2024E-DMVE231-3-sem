using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Query.QueryDto
{
    public class ReviewDto
    {
        public int Id { protected get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

        public int AccommodationId { get; set; }
        public int GuestId { get; set; }
        public int BookingId { get; set; }
    }
}
