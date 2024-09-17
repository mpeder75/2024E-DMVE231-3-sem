using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{

    public class HostRepository : IHostRepository
    {

        private readonly BookMyHomeContext _db;


        void IHostRepository.AddHost(Host host)
        {
            _db.Hosts.Add(host);
            _db.SaveChanges();        }

        void IHostRepository.DeleteHost(int id, byte[] rowVersion)
        {
            var host = _db.Hosts.Find(id);
            if (host != null)
            {
                _db.Entry(host).Property(nameof(host.RowVersion)).OriginalValue = rowVersion;
                _db.Hosts.Remove(host);
                _db.SaveChanges();
            }
        }

        Host IHostRepository.GetHost(int id)
        {
            return _db.Hosts.Include(h => h.Accommodations).SingleOrDefault(h => h.Id == id);
        }

        IEnumerable<Host> IHostRepository.GetHosts()
        {
            return _db.Hosts.Include(h => h.Accommodations).ToList();
        }

        void IHostRepository.UpdateHost(Host host, byte[] rowVersion)
        {
            _db.Entry(host).Property(nameof(host.RowVersion)).OriginalValue = rowVersion;
            _db.Hosts.Update(host);
            _db.SaveChanges();
        }
    }
}
