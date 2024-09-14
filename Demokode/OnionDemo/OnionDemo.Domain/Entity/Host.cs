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
    }
}
