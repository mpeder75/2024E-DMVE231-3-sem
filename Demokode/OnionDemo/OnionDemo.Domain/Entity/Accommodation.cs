using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Accommodation : DomainEntity
    {
        public string Name { get; protected set; }
        public string Location { get; protected set; }
        // Navigation properties
        public int HostId { get; protected set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        protected Accommodation() {}

        protected Accommodation(String name, string location, int hostId)
        {
            Name = name;
            Location = location;
            HostId = hostId;
        }

        public static Accommodation Create(string name, string location, int hostId)
        {
            return new Accommodation(name, location, hostId);
        }

        public void Update(string name, string location, int hostId)
        {
            Name = name;
            Location = location;
            HostId = hostId;
        }
    }
}

