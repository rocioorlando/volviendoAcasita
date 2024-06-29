using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;

namespace VolviendoACasita.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; }
        ILostFoundFormRepository Form { get; }
        IAddressRepository Address { get; }
        IPetRepository Pet { get; }
        IArchiveRepository Archives { get; }
        IRequestRepository Request { get; }

        IProvinceRepository Province { get; }
        ILocationRepository Location { get; }
        IBreedRepository Breed { get; }
        ISpeciesRepository Species { get; }


        void Save();
    }
}
