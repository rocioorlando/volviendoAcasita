using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ApplicationDbContext _db;
        private readonly IMapper mapper;

        public UserRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
            _db = db;
            this.mapper = mapper;
        }

        public void Update(UserDto userDto)
        {
            dbSet.Update(ConvertDtoToEntity<User, UserDto>(userDto));
        }

        public async Task UpdateAsync(UserDto userDto)
        {
            var newEntity = ConvertDtoToEntity<User, UserDto>(userDto);
            await EditItem(newEntity.Id, newEntity);
        }

        public void Add(UserDto userDto)
        {
            dbSet.Add(ConvertDtoToEntity<User, UserDto>(userDto));
        }
        public UserDto GetUserByUserName(string userName)
        {
            var properties = "Address,Address.Location,Address.Province";
            var form = Get(x => x.UserName == userName && x.IsDeleted == false, properties);
            return ConvertEntityToDto<User, UserDto>(form);
        }
        public void UpdateField(int userId, string fieldName, object newValue)
        {
            var user = dbSet.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var property = user.GetType().GetProperty(fieldName);

                if (property != null)
                {
                    property.SetValue(user, newValue);
                    user.VerifyPassword = true;
                    user.UpdatedDate = DateTime.Now;
                    _db.SaveChanges();
                }
                else
                {
                    // Manejar el caso donde el nombre del campo no existe en la entidad
                    throw new ArgumentException($"El campo '{fieldName}' no existe en la entidad User.");
                }
            }
            else
            {
                // Manejar el caso donde el usuario con el ID dado no existe
                throw new ArgumentException($"No se encontró ningún usuario con el ID '{userId}'.");
            }
        }

        public UserDto GetUser(int id)
        {
            User user = GetEntity(id);
            return ConvertEntityToDto<User, UserDto>(user);
        }

        private User GetEntity(int id)
        {
            var properties = "Address,Address.Location,Address.Province";
            var user = Get(x => x.Id == id && x.IsDeleted == false, properties);
            return user;
        }

    }


}
