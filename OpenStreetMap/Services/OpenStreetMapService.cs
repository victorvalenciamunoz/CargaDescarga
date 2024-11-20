using System.Text.Json;

namespace CargaDescarga.OpenStreetMap;

public class OpenStreetMapService
{
    private readonly HttpClient _httpClient;

    public OpenStreetMapService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CustomPlace>> GetOpenStreetMapAsync(string address)
    {
        List<CustomPlace> result;
        var url = $"?q={address}&format=json&addressdetails=1";
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
        string decimalSeparator = ci.NumberFormat.NumberDecimalSeparator;

        if (response.IsSuccessStatusCode)
        {
            result = new List<CustomPlace>();
            string content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<SearchResponse>>(content);
            if (data.Any())
            {
                result = new List<CustomPlace>();
                foreach (var place in data.OrderByDescending(c=> c.importance))
                {
                    if (place.address.country_code == "es")
                    {
                        result.Add(new CustomPlace
                        {
                            Description = place.display_name,
                            Latitude = Convert.ToDecimal(place.lat.Replace(".", decimalSeparator)),
                            Longitude = Convert.ToDecimal(place.lon.Replace(".", decimalSeparator))
                        });
                    }
                }

                return result;
            }
        }

        return Enumerable.Empty<CustomPlace>();
    }
}
