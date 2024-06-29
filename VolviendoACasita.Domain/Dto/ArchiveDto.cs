using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class ArchiveDto
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }
}
