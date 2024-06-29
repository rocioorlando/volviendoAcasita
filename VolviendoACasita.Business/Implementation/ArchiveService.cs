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
    public class ArchivesService : IArchivesService
    {
        private readonly IUnitOfWork unitOfWork;
        public ArchivesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddArchives(Archive obj)
        {
            unitOfWork.Archives.Add(obj);
        }
    }
}
