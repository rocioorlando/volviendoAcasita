using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository
{
    public class PetRepository: Repository<Pet>, IPetRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper mapper;

        public PetRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            this.mapper = mapper;
        }
        public void Add(PetDto petDto)
        {
            dbSet.Add(ConvertDtoToEntity<Pet, PetDto>(petDto));
        }
        public void Update(Pet obj)
        {
            dbSet.Update(obj);
        }

        public List<PetDto> GetAllPet()
        {
            var pets = GetAll();
            return ConvertEntityToDto<IEnumerable<Pet>, IEnumerable<PetDto>>(pets).ToList();
        }

        public List<PetDto> GetAllPetByUser(int userId)
        {
            var properties = "User,Breed,Breed.Species,Archive";
            var pets = GetAll(x => x.UserId == userId && x.IsDeleted == false, properties);
            return ConvertEntityToDto<IEnumerable<Pet>, IEnumerable<PetDto>>(pets).ToList();
        }

        public PetDto GetPet(int id)
        {
            var properties = "User,Breed,Breed.Species,Archive";
            var pet = Get(x => x.Id == id && x.IsDeleted == false, properties);
            return ConvertEntityToDto<Pet, PetDto>(pet);
        }
        public async Task UpdateAsync(PetDto petDto)
        {
            var newEntity = ConvertDtoToEntity<Pet, PetDto>(petDto);
            await EditItem(newEntity.Id, newEntity);
        }
    }
}
