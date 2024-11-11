using System;
class Aerolinea
{
    private List<Vuelo> vuelos = new List<Vuelo>();

    public void AgregarVuelo(Vuelo vuelo)
    {
        vuelos.Add(vuelo);
    }

    public Vuelo BuscarVuelo(string codigo)
    {
        string codigoMinuscula = codigo.ToLower(); 

        foreach (Vuelo vuelo in vuelos) 
        {
            if (vuelo != null && vuelo.CodigoVuelo.ToLower() == codigoMinuscula)
            {
                return vuelo; // Retorna el vuelo si se encuentra
            }
        }
        return null; // Retorna null si no se encuentra
    }

    public double CalcularOcupacionMedia()
    {
        if (vuelos.Count == 0) return 0; // Retorna 0 si no hay vuelos

        double sumaOcupacion = 0; 
        int cantidadVuelos = 0; 

        foreach (Vuelo vuelo in vuelos) 
        {
            sumaOcupacion += vuelo.CalcularOcupacion(); 
            cantidadVuelos++; 
        }
        return sumaOcupacion / cantidadVuelos; // Retorna la ocupación media
    }

    public Vuelo ObtenerVueloConMayorOcupacion()
    {
        Vuelo vueloConMayorOcupacion = null; // Inicializa para el vuelo con mayor ocupación
        double mayorOcupacion = 0; 

        foreach (Vuelo vuelo in vuelos) 
        {
            double ocupacionActual = vuelo.CalcularOcupacion(); 

            if (ocupacionActual > mayorOcupacion) 
            {
                mayorOcupacion = ocupacionActual; 
                vueloConMayorOcupacion = vuelo; 
            }
        }
        return vueloConMayorOcupacion; // Retorna el vuelo con mayor ocupación, o null si no hay vuelos
    }
    public List<Vuelo> ListarVuelosOrdenadosPorOcupacion()
    {
        List<Vuelo> vuelosOrdenados = new List<Vuelo>(); 

        foreach (Vuelo vuelo in vuelos)
        {
            vuelosOrdenados.Add(vuelo);
        }

        // Ordena la lista de vuelos por ocupación usando el metodo burbuja
        for (int i = 0; i < vuelosOrdenados.Count - 1; i++)
        {
            for (int j = 0; j < vuelosOrdenados.Count - 1 - i; j++)
            {
                if (vuelosOrdenados[j].CalcularOcupacion() < vuelosOrdenados[j + 1].CalcularOcupacion())
                {
                    // Intercambia los vuelos si están en el orden incorrecto
                    Vuelo temporal = vuelosOrdenados[j];
                    vuelosOrdenados[j] = vuelosOrdenados[j + 1];
                    vuelosOrdenados[j + 1] = temporal;
                }
            }
        }
        }
        return vuelosOrdenados; // Retorna la lista de vuelos ordenados
    }

    public List<Vuelo> ObtenerVuelos()
    {
        return vuelos;
    }
}
