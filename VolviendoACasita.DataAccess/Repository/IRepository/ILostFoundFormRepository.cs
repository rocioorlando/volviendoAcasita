using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.DataAccess.Repository.IRepository
{
    public interface ILostFoundFormRepository : IRepository<LostFoundForm>
    {
        void Add(LostFoundFormDto userDto);
        Task UpdateAsync(LostFoundFormDto formDto);
        LostFoundFormDto GetForm(int id);
        List<LostFoundFormDto> GetAllForm();
    }
}
