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
    public interface IUserRepository : IRepository<User>
    {
        void Update(UserDto userDto);
        void UpdateField(int userId, string fieldName, object newValue);
        void Add(UserDto userDto);
        UserDto GetUserByUserName(string userName);
        Task UpdateAsync(UserDto userDto);
        UserDto GetUser(int id);

    }
}
