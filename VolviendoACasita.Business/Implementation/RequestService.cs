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
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork unitOfWork;
        public RequestService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddRequest(Request obj)
        {
            unitOfWork.Request.Add(obj);
        }
    }
}
