using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Entity;

namespace VolviendoACasita.Domain.Dto
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
