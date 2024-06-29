using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string BetweenStreet { get; set; }
        public int Number { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public int ProvinceId { get; set; }
        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ProvinceDto Province { get; set; }
        public LocationDto Location { get; set; }   
    }
}
