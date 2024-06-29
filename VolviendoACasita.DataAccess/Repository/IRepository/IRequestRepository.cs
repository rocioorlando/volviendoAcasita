using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository.IRepository
{
    public interface IRequestRepository : IRepository<Request>
    {
        void Update(Request obj);
    }
}
