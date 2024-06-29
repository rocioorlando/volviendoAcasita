using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Dto
{
    public class BreedDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SpeciesId { get; set; }
        public SpeciesDto Species { get; set; }
    }
}
