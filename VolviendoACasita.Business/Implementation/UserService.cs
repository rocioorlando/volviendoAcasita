using AutoMapper;
using Microsoft.Extensions.Logging;
using Serilog.Configuration;
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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public readonly ILogger<UserService> logger;
        private readonly IMapper mapper;
        private readonly GeoCodeService geoCodeService;

        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper, GeoCodeService geoCodeService)
        {

            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
            this.geoCodeService = geoCodeService;
        }

        public async Task<ResultDto> AddUserWithExceptionHandling(UserDto dto)
        {
            try
            {
                return await AddUserToDatabase(dto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        private async Task<ResultDto> AddUserToDatabase(UserDto obj)
        {
            var result = new ResultDto();
            ValidatedUser(result, obj);

            if (result.IsSuccess)
            {
                await CompleteLatitudeAndLongitude(obj);  // Llama al método asincrónico
                obj.Password = SetRandomPassword();
                unitOfWork.User.Add(obj);
                await unitOfWork.User.SaveAsync();  // Asegúrate de que Save también sea asincrónico
            }
            else
            {
                return result;
            }
            return result;
        }

        private void ValidatedUser(ResultDto result, UserDto obj)
        {
            if (string.IsNullOrEmpty(obj.Name))
            {
                result.Errors.Add("El Nombre es obligatorio.");
            }
            else if (string.IsNullOrEmpty(obj.Email))
            {
                result.Errors.Add("El E-mail es obligatorio.");
            }
            else if (string.IsNullOrEmpty(obj.Password))
            {
                result.Errors.Add("Debe ingresar una contraseña.");
            }
            else if (string.IsNullOrEmpty(obj.UserName))
            {
                result.Errors.Add("Debe ingresar el nombre de Usuario.");
            }
            else if (string.IsNullOrEmpty(obj.LastName))
            {
                result.Errors.Add("Debe ingresar el nombre de Usuario.");
            }
            else if (string.IsNullOrEmpty(obj.Dni))
            {
                result.Errors.Add("Debe ingresar el DNI.");
            }
            else if (obj.Birthdate == DateTime.MinValue)
            {
                result.Errors.Add("La Fecha de Nacimiento no puede estar vacio.");
            } else if  (string.IsNullOrEmpty(obj.CellPhone))
            {
                result.Errors.Add("Debe ingresar un numero de telefono");
            } else if  (obj.Address.PostalCode == 0 )
            {
                result.Errors.Add("Debe ingresar el codigo postal");
            }
        }

        public string SetRandomPassword()
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder contrasenia = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                int index = rnd.Next(caracteres.Length);
                contrasenia.Append(caracteres[index]);
            }
            return contrasenia.ToString();
        }

        public UserDto GetUserByUserName(string userName)
        {
            return unitOfWork.User.GetUserByUserName(userName);
        }
        public async Task UpdateUser(UserDto user)
        {
            try
            {
                await unitOfWork.User.UpdateAsync(user);
                await unitOfWork.User.SaveAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<ResultDto> UpdatePassword(UserDto userDto)
        {
            var result = new ResultDto();

            try
            {
               var user = GetUserByUserName(userDto.UserName); 
                result = CheckPassword(result, userDto);

                if (result.IsSuccess)
                {
                    result = CheckUserExistence(result, user);
                    if (result.IsSuccess)
                    {
                        user.Password = userDto.NewPass;
                        user.UpdatedDate = DateTime.Now;
                        user.VerifyPassword = true;

                        await UpdateUser(user); 

                        result.UserDto = user;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
            }

            return result;
        }


        private ResultDto CheckPassword(ResultDto result, UserDto obj)
        {
            if (string.IsNullOrEmpty(obj.UserName))
            {
                result.Errors.Add("El Nombre es obligatorio.");
            }
            if (string.IsNullOrEmpty(obj.OldPass))
            {
                result.Errors.Add("La contraseña vieja es obligatoria");
            }
            if (string.IsNullOrEmpty(obj.NewPass))
            {
                result.Errors.Add("La contraseña nueva es obligatoria");
            }
            if (string.IsNullOrEmpty(obj.ConfirmPassword))
            {
                result.Errors.Add("La confirmacion de la contraseña es obligatoria");
            }

            return result;
        }

        private ResultDto CheckUserExistence(ResultDto result, UserDto obj)
        {
            if (!CheckExistence(obj))
            {
                result.Errors.Add("El usuario no existe");
            }

            return result;
        }

        public bool CheckExistence(UserDto user)
        {
            return user != null;
        }

        public UserDto Get(int id)
        {
            return unitOfWork.User.GetUser(id);
        }

        private async Task CompleteLatitudeAndLongitude(UserDto user) 
        {
            var address = CreateAddress(user);
            try
            {
                var geoCodeResult = await geoCodeService.GetCoordinatesAsync(address);
                user.Address.Latitude = geoCodeResult.Latitude;
                user.Address.Longitude = geoCodeResult.Longitude;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        } 

        private string CreateAddress(UserDto user) 
        {
            // Formatear la dirección
            string address = $"{user.Address.Street + " " + user.Address.Number}, " +
                             $"{user.Address.City}, " +
                             $"{user.Address.PostalCode.ToString()}, " +
                             $"{"Buenos Aires"}, " +
                             $"{"Argentina"}";
            return address;
        }
    }
}
