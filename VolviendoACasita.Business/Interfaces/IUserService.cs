using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Business.Interfaces
{
    public interface IUserService
    {
        Task<ResultDto> AddUserWithExceptionHandling(UserDto dto);
        UserDto GetUserByUserName(string mail);
        public string SetRandomPassword();
        Task<ResultDto> UpdatePassword(UserDto userDto);
        UserDto Get(int id);
        Task UpdateUser(UserDto user);
    }
}
