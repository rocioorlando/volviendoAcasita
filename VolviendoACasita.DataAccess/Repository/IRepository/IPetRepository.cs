using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository.IRepository
{
    public interface IPetRepository : IRepository<Pet>
    {
        void Add(PetDto petDto);
        void Update(Pet obj);
        PetDto GetPet(int id);
        Task UpdateAsync(PetDto petDto);
        List<PetDto> GetAllPet();
        List<PetDto> GetAllPetByUser(int userId);
    }
}
