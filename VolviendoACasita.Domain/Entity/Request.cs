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
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public int FormId { get; set; }
        [ForeignKey("FormId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public LostFoundForm Form { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
