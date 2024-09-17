using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IHostRepository
    {
        void AddHost(Host host);
        void UpdateHost(Host host, byte[] rowVersion);
        void DeleteHost(int id, byte[] rowVersion);
        Host GetHost(int id);
        IEnumerable<Host> GetHosts();
    }
}
