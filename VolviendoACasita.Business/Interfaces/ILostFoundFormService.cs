using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Interfaces
{
    public interface ILostFoundFormService
    {
        Task<ResultDto> AddFormWithExceptionHandling(LostFoundFormDto obj);
        void AddForm(LostFoundFormDto obj);
        LostFoundFormDto Get(int id);
        Task<ResultDto> UpdateFormWithExceptionHandlingAsync(LostFoundFormDto obj);
        List<LostFoundFormDto> GetAllForm();

    }
}
