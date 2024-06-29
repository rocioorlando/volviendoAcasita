using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;

namespace VolviendoACasita.Business.Interfaces
{
    public interface IAuthenticationService
    {
        ResultDto AuthenticateUser(string mail, string password);
    }
}
