using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Implementation
{
    public class AddressService : IAddressService
    {

        private readonly IUnitOfWork unitOfWork;
        public AddressService(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        public void AddAddress(Address obj)
        {
            unitOfWork.Address.Add(obj);
        }
    }
}
