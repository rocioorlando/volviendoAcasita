using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int? AddressId { get; set; }
        public string CellPhone { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool VerifyPassword { get; set; }
        public bool? IsDeleted { get; set; }
        public string OldPass { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPassword { get; set; }
        public AddressDto? Address { get; set; }
    }
}
