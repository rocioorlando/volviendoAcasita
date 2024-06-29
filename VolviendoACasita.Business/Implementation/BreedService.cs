using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Implementation
{
    public class BreedService : IBreedService
    {
        private readonly IUnitOfWork unitOfWork;
        public BreedService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Breed> GetAll()
        {
            return unitOfWork.Breed.GetAll().ToList();
        }
    }
}
