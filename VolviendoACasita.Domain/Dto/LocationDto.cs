using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
