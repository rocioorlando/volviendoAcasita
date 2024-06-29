using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Entity
{
    public class LostFoundForm
    {
        [Key]
        public int Id { get; set; }
        public int PetId { get; set; }
        public int CreatedById { get; set; }
        public DateTime? MeetingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Observation { get; set; }
        public int LostFoundLocationId { get; set; }
        public string ContactPhone { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime PetLostFoundDate { get; set; }
        public int? VeterinaryId { get; set; }
        public int FormStatusId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("PetId")]
        [DeleteBehavior(DeleteBehavior.Restrict)] 
        public Pet Pet { get; set; } = new Pet();
        [ForeignKey("CreatedById")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User CreatedBy { get; set; }

        [ForeignKey("LostFoundLocationId")]
        public Address LostFoundLocation { get; set; }

        [ForeignKey("VeterinaryId")]
        public Veterinary Veterinary { get; set; }

    }
}
