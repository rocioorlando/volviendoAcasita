using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Interfaces
{
    public interface IPetService
    {
        ResultDto AddPetWithExceptionHandling(PetDto obj);
        PetDto ConvertEntityToDto(Pet pet);
        PetDto GetPet(int id);
        List<PetDto> GetAll();
        List<PetDto> GetAllPetByUser(int userId);
        Task<ResultDto> UpdateFormWithExceptionHandlingAsync(PetDto obj);
    }
}
