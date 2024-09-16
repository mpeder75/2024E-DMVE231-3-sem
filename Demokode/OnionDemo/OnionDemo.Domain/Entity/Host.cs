using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public List<Accommodation> Accommodations { get; protected set; } = new List<Accommodation>();

        protected Host(String name, String email)
        {
            Name = name;
            Email = email;
        }

        public static Host Create(string name, string email)
        {
            return new Host(name, email);
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void AddAccommodation(string name, string location)
        {
            var accommodation = Accommodation.Create(name, location, this.Id);
            Accommodations.Add(accommodation);
        }

        public void UpdateAccommodation(int accommodationId, string name, string location)
        {
            var accommodation = Accommodations.SingleOrDefault(a => a.Id == accommodationId);
            if (accommodation == null) throw new Exception("Accommodation not found");

            accommodation.Update(name, location, this.Id);
        }

        public void DeleteAccommodation(int accommodationId)
        {
            var accommodation = Accommodations.SingleOrDefault(a => a.Id == accommodationId);
            if (accommodation == null) throw new Exception("Accommodation not found");

            Accommodations.Remove(accommodation);
        }
    }
}
