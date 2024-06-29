using System;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class LostFoundFormDto
    {
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
        public bool IsDeleted { get; set; }

        public PetDto? Pet { get; set; }
        public UserDto? CreatedBy { get; set; }
        public AddressDto? LostFoundLocation { get; set; }
        public VeterinaryDto? Veterinary { get; set; }
    }
}
