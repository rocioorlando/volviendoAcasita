using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Interfaces
{
    public interface ILocationService
    {
        List<Location> GetAll();
    }
}
