using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.DataAccess.Repository.IRepository;

namespace VolviendoACasita.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private IMapper mapper;
        public IUserRepository User { get; private set; }
        public ILostFoundFormRepository Form { get; private set; }
        public IAddressRepository Address { get; private set; } 
        public IPetRepository Pet { get; private set; }
        public IArchiveRepository Archives { get; private set; }
        public IRequestRepository Request { get; private set; }

        public IProvinceRepository Province { get; private set; }
        public ILocationRepository  Location { get; private set; }
        public IBreedRepository Breed { get; private set; }
        public ISpeciesRepository Species { get; private set; }

        public UnitOfWork(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            User = new UserRepository(db, mapper);
            Form = new LostFoundFormRepository(db, mapper);
            Address = new AddressRepository(db, mapper);
            Pet = new PetRepository(db, mapper);
            Archives = new ArchiveRepository(db, mapper);
            Request = new RequestRepository(db, mapper);
            Province = new ProvinceRepository(db, mapper);
            Location = new LocationRepository(db, mapper);
            Breed = new BreedRepository(db, mapper);
            Species = new SpeciesRepository(db, mapper);
            Form = new LostFoundFormRepository(db, mapper);

        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
