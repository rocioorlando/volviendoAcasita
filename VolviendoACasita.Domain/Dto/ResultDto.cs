using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolviendoACasita.Domain.Dto
{
    public class ResultDto
    {
        public List<string> Errors { get; set; } = new List<string>();
        public UserDto UserDto { get; set; }
        public LostFoundFormDto LostFoundFormDto { get; set; }

        public bool IsSuccess
        {
            get
            {
                return Errors.Count == 0;
            }
        }
    }
}
