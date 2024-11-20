namespace CargaDescarga.Pois;


public class PoiResponse
{
    public float latitud { get; set; }
    public float longitud { get; set; }
    public string descripcion { get; set; }
    public string distrito { get; set; }
    public string barrio { get; set; }
    public string calle { get; set; }
    public string numFinca { get; set; }
    public string tipoReserva { get; set; }
    public string formaAparcamiento { get; set; }
    public int numPlazas { get; set; }
    public string texto { get; set; }
    public string urlImagen { get; set; }
    public float distanciaAPosicionActual { get; set; }
}

