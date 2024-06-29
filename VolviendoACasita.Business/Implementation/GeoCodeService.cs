using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using VolviendoACasita.Business.Interfaces;

namespace VolviendoACasita.Business.Implementation
{
    public class GeoCodeService: IGeoCodeService
    {
        private readonly HttpClient _httpClient;
        public readonly ILogger<GeoCodeService> logger;

        public GeoCodeService(HttpClient httpClient, ILogger<GeoCodeService> logger)
        {
            _httpClient = httpClient;
            logger = logger;
        }

        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(address)}&format=json&addressdetails=1";
                var response = await _httpClient.GetStringAsync(url);
                var json = JArray.Parse(response);

                if (json.Count == 0)
                {
                    logger.LogError("No se encontraron coordenadas para la dirección proporcionada.");
                }

                var firstResult = json[0];
                double latitude = firstResult.Value<double>("lat");
                double longitude = firstResult.Value<double>("lon");

                return (latitude, longitude);
            }
            catch (HttpRequestException httpEx)
            {
                logger.LogError("Error al intentar obtener coordenadas: Error de red.", httpEx);
                return (0, 0);
            }
            catch (JsonException jsonEx)
            {;
                logger.LogError("Error al procesar la respuesta de coordenadas.", jsonEx);
                return (0, 0);
            }
            catch (Exception ex)
            {
                logger.LogError("Error inesperado al obtener coordenadas.", ex);
                return (0, 0);
            }
        }
    }
}
