using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Entity
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int SpeciesId { get; set; }
        [ForeignKey("SpeciesId")]
        public Species Species { get; set; }
    }
}
