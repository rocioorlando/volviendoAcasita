using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolviendoACasita.Domain.Dto;

namespace VolviendoACasita.Business.Interfaces
{
    public interface IGeoCodeService
    {
        Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address);
    }
}
