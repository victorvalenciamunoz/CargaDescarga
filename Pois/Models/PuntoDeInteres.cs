﻿namespace CargaDescarga.Pois.Models;

public class PuntoDeInteres
{
    public double Latitud { get; set; }
    public double Longitud { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public string Distrito { get; set; } = string.Empty;

    public string Barrio { get; set; } = string.Empty;

    public string Calle { get; set; } = string.Empty;

    public string NumFinca { get; set; } = string.Empty;

    public string TipoReserva { get; set; } = string.Empty;

    public string FormaAparcamiento { get; set; } = string.Empty;

    public int NumPlazas { get; set; }

    public string Texto { get; set; } = string.Empty;

    public double DistanciaAPosicionActual { get; set; }

    public string UrlImagen { get; set; } = string.Empty;
}
