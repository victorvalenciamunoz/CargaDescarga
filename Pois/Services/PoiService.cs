using CargaDescarga.Pois.Models;
using System.Text;
using System.Text.Json;

namespace CargaDescarga.Pois;

public class PoiService
{
    private readonly HttpClient _httpClient;
    public PoiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PuntoDeInteres>> GetPoisAsync(double latitud, double longitud, int numeroPagina, int registrosPagina)
    {
        List<PuntoDeInteres> result;

        StringBuilder request = new StringBuilder("puntosdeinteres");
        request.Append($"?posicionLatitud={latitud.ToString().Replace(",", ".")}");
        request.Append($"&posicionLongitud={longitud.ToString().Replace(",", ".")}");

        HttpResponseMessage response = await _httpClient.GetAsync(request.ToString());

        if (response.IsSuccessStatusCode)
        {
            result = new List<PuntoDeInteres>();
            string content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<PoiResponse>>(content);
            if (data.Any())
            {
                result = new List<PuntoDeInteres>();
                foreach (var poi in data)
                {
                    result.Add(new PuntoDeInteres
                    {
                        Barrio = poi.barrio,
                        Calle = poi.calle,
                        Descripcion = poi.descripcion,
                        DistanciaAPosicionActual = poi.distanciaAPosicionActual,
                        Distrito = poi.distrito,
                        FormaAparcamiento = poi.formaAparcamiento,
                        UrlImagen = poi.urlImagen,
                        Latitud = poi.latitud,
                        Longitud = poi.longitud,
                        NumFinca = poi.numFinca,
                        NumPlazas = poi.numPlazas,
                        Texto = poi.texto,
                        TipoReserva = poi.tipoReserva
                    });
                }

                return result;
            }
        }

        return Enumerable.Empty<PuntoDeInteres>();
    }
}
