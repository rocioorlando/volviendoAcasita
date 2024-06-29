using AutoMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.DataAccess.Data;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository
{
    public class LostFoundFormRepository : Repository<LostFoundForm>, ILostFoundFormRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper mapper;

        public LostFoundFormRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            this.mapper = mapper;
        }

        public void Add(LostFoundFormDto formDto)
        {
            dbSet.Add(ConvertDtoToEntity<LostFoundForm, LostFoundFormDto>(formDto));
        }

        public async Task UpdateAsync(LostFoundFormDto formDto)
        {
            var newEntity = ConvertDtoToEntity<LostFoundForm, LostFoundFormDto>(formDto);
            await EditItem(newEntity.Id, newEntity);
        }

        public LostFoundFormDto GetForm(int id)
        {
            LostFoundForm form = GetEntity(id);
            return ConvertEntityToDto<LostFoundForm, LostFoundFormDto>(form);
        }

        private LostFoundForm GetEntity(int id)
        {
            var properties = "Pet,Pet.Archive,LostFoundLocation,LostFoundLocation.Location";
            var form = Get(x => x.Id == id && x.IsDeleted == false, properties);
            return form;
        }

        public List<LostFoundFormDto> GetAllForm()
        {
            var properties = "Pet,Pet.Archive,LostFoundLocation,LostFoundLocation.Province,LostFoundLocation.Location";
            var forms = GetAll(null, properties);
            return ConvertEntityToDto<IEnumerable<LostFoundForm>, IEnumerable<LostFoundFormDto>>(forms).ToList();
        }

    }
}
