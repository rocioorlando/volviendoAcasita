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
    public class SpeciesService : ISpeciesService
    {
        private readonly IUnitOfWork unitOfWork;
        public SpeciesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Species> GetAll()
        {
            return unitOfWork.Species.GetAll().ToList();
        }
    }
}
