using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Entity
{
    public class Species
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

    }
}
