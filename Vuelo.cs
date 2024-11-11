using System;
using System.Collections.Generic;
using System.Linq;

// Clase que representa un vuelo
class Vuelo
{
    public string CodigoVuelo { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaLlegada { get; set; }
    public string NombrePiloto { get; set; }
    public string NombreCopiloto { get; set; }
    public int CapacidadMaxima { get; set; }
    public int PasajerosRegistrados { get; set; }

    public Vuelo(string codigoVuelo, DateTime fechaSalida, DateTime fechaLlegada, string nombrePiloto, string nombreCopiloto, int capacidad)
    {
        CodigoVuelo = codigoVuelo;
        FechaSalida = fechaSalida;
        FechaLlegada = fechaLlegada;
        NombrePiloto = nombrePiloto;
        NombreCopiloto = nombreCopiloto;
        CapacidadMaxima = capacidad;
        PasajerosRegistrados = 0;
    }

    public double CalcularOcupacion()
    {
        return (double)PasajerosRegistrados / CapacidadMaxima * 100;
    }
}
