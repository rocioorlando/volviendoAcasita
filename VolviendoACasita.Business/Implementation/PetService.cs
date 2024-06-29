using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Business.Interfaces;
using VolviendoACasita.DataAccess.Repository.IRepository;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace VolviendoACasita.Business.Implementation
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork unitOfWork;
        public readonly ILogger<UserService> logger;
        private readonly IMapper mapper;
        public PetService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
        }

        public PetDto GetPet(int id)
        {
            return unitOfWork.Pet.GetPet(id);
        }

        public List<PetDto> GetAll()
        {
            return unitOfWork.Pet.GetAllPet();
        }

        public List<PetDto> GetAllPetByUser(int userId)
        {
            return unitOfWork.Pet.GetAllPetByUser(userId);
        }

        public ResultDto AddPetWithExceptionHandling(PetDto obj)
        {
            try
            {
                return AddPetToDatabase(obj);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        private ResultDto AddPetToDatabase(PetDto obj)
        {
            var result = new ResultDto();
            ValidatedPet(result, obj);
            if (result.IsSuccess)
            {
                unitOfWork.Pet.Add(obj);
                unitOfWork.Save();
            }
            else
            {
                return result;
            }
            return result;
        }

        private void ValidatedPet(ResultDto result, PetDto obj)
        {
            if (string.IsNullOrEmpty(obj.Name))
            {
                result.Errors.Add("El Nombre es obligatorio.");
            }
            else if (obj.Age == 0)
            {
                result.Errors.Add("La edad es obligatoria. ");
            }
            else if (obj.Weight == 0)
            {
                result.Errors.Add("Debe ingresar un peso.");
            }
            else if (string.IsNullOrEmpty(obj.Color))
            {
                result.Errors.Add("Debe ingresar un color. ");
            }
            else if (obj.IsOnMedication == true && string.IsNullOrEmpty(obj.MedicationNotes))
            {
                result.Errors.Add("Debe ingresar el tipo de medicacion que recibe su mascota.");
            }
        }

        public PetDto ConvertEntityToDto(Pet pet)
        {
            var petDto = mapper.Map<PetDto>(pet);
            return petDto;
        }

        public async Task<ResultDto> UpdateFormWithExceptionHandlingAsync(PetDto obj)
        {
            try
            {
                return await UpdateFormToDatabaseAsync(obj);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        private async Task<ResultDto> UpdateFormToDatabaseAsync(PetDto obj)
        {
            var result = new ResultDto();
            ValidatedPet(result, obj);
            if (result.IsSuccess)
            {
                obj.UpdatedDate = DateTime.Now;
                await unitOfWork.Pet.UpdateAsync(obj);
                await unitOfWork.Pet.SaveAsync();
            }
            else
            {
                return result;
            }
            return result;
        }

    }
}
