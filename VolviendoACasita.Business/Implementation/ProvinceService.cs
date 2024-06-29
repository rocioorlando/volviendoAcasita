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
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Province> GetAll()
        {
            
            return unitOfWork.Province.GetAll().ToList();

        }


        
    }
}
