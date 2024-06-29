﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class PetDto
    {
        public int Id { get; set; }
        public int? SizeId { get; set; }
        public int UserId { get; set; }
        public UserDto? User { get; set; }
        public int BreedId { get; set; }
        public BreedDto? Breed { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public decimal? Weight { get; set; }
        public string? Color { get; set; }
        public bool? IsCastrated { get; set; }
        public bool? IsOnMedication { get; set; }
        public string? RespondsTo { get; set; }
        public bool? IsVaccinated { get; set; }
        public string? MedicationNotes { get; set; }
        public bool IsOwner { get; set; }
        public bool? HasVifVilef { get; set; }
        public bool? HasTag { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<ArchiveDto>? Archive { get; set; }
    }
}