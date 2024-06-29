using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int AddressId { get; set; }     
        public string CellPhone { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsLocked { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool VerifyPassword { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("AddressId")]
        public Address Address { get; set; }


    }
}
