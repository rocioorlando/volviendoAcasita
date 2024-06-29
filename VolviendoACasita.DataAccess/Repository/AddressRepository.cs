using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper mapper;

        public AddressRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            this.mapper = mapper;
        }


        public void Add(Address obj)
        {

            dbSet.Add(obj);
        }


    }
}
