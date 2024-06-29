using AutoMapper;
using Microsoft.Extensions.Logging;
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
    public class LostFoundFormService : ILostFoundFormService
    {
        private readonly IUnitOfWork unitOfWork;
        public readonly ILogger<LostFoundFormService> logger;
        private readonly GeoCodeService geoCodeService;

        public LostFoundFormService(IUnitOfWork unitOfWork, ILogger<LostFoundFormService> logger, GeoCodeService geoCodeService)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.geoCodeService = geoCodeService;
        }
        public void AddForm(LostFoundFormDto obj)
        {
            unitOfWork.Form.Add(obj);
        }

        public async Task<ResultDto> AddFormWithExceptionHandling(LostFoundFormDto obj)
        {
            try
            {
                return await AddFormToDatabase(obj);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }

        }

        private async Task<ResultDto> AddFormToDatabase(LostFoundFormDto obj)
        {
            var result = new ResultDto();
            ValidateForm(result, obj);
            if (result.IsSuccess)
            {
                await CompleteLatitudeAndLongitude(obj);  // Llama al método asincrónico
                unitOfWork.Form.Add(obj);
                unitOfWork.Save();
            }
            else
            {
                return result;
            }
            return result;
        }

        public List<LostFoundFormDto> GetAllForm()
        {
            return unitOfWork.Form.GetAllForm();
        }

        public LostFoundFormDto Get(int id)
        {
            return unitOfWork.Form.GetForm(id);
        }
        private void ValidateForm(ResultDto result, LostFoundFormDto obj)
        {
            if (string.IsNullOrEmpty(obj.ContactPhone))
            {
                result.Errors.Add("El numero de contacto es obligatorio");
            }
            else if (obj.PetLostFoundDate == DateTime.MinValue)
            {
                result.Errors.Add("La Fecha no puede estar vacio.");
            }
            if(obj.Id == 0 && GetAllForm().Any(x => x.PetId == obj.PetId))
            {
                result.Errors.Add("Ya existe un formulario abierto para esta mascota");
            }
        }

        public async Task<ResultDto> UpdateFormWithExceptionHandlingAsync(LostFoundFormDto obj)
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

        private async Task<ResultDto> UpdateFormToDatabaseAsync(LostFoundFormDto obj)
        {
            var result = new ResultDto();
            ValidateForm(result, obj);
            if (result.IsSuccess)
            {
                obj.UpdatedDate = DateTime.Now;
                await unitOfWork.Form.UpdateAsync(obj);
                await unitOfWork.Form.SaveAsync();
            }
            else
            {
                return result;
            }
            return result;
        }

          private async Task CompleteLatitudeAndLongitude(LostFoundFormDto form) 
        {
            var address = CreateAddress(form);
            try
            {
                var geoCodeResult = await geoCodeService.GetCoordinatesAsync(address);
                form.LostFoundLocation.Latitude = geoCodeResult.Latitude;
                form.LostFoundLocation.Longitude = geoCodeResult.Longitude;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        } 

        private string CreateAddress(LostFoundFormDto form)
        {
            // Formatear la dirección
            string address = $"{form.LostFoundLocation.Street + " " + form.LostFoundLocation.Number}, " +
                             $"{form.LostFoundLocation.City}, " +
                             $"{form.LostFoundLocation.PostalCode.ToString()}, " +
                             $"{"Buenos Aires"}, " +
                             $"{"Argentina"}";
            return address;
        }
    }
}
