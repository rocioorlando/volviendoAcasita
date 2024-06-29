using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        public void Add(Address obj);
    }
}
