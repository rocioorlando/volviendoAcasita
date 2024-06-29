using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Entity
{
    public class Archive
    {
        [Key]
        public int Id { get; set; }
        public int PetId { get; set; }
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }

    }
}
