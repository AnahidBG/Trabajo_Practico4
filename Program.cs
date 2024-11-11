using System;

class Program
{
    static Aerolinea aerolinea = new Aerolinea();
    static bool vuelosCreado = false;
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            MostrarMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    AgregarVuelo();
                    break;
                case "2":
                    RegistrarPasajeros();
                    break;
                case "3":
                    CalcularOcupacionMedia();
                    break;
                case "4":
                    VueloConMayorOcupacion();
                    break;
                case "5":
                    BuscarVueloPorCodigo();
                    break;
                case "6":
                    ListarVuelosPorOcupacion();
                    break;
                case "7":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    //Muestra menu de lo que se puede hacer
    static void MostrarMenu()
    {
        Console.WriteLine("------BIENVENIDOS A LA AEROLINEA------");
        Console.WriteLine("¿Qué queres hacer?:" +
        "\n1. Agregar un vuelo" +
        "\n2. Registrar pasajeros en un vuelo" +
        "\n3. Calcular ocupación media de la flota"+
        "\n4. Vuelo con mayor ocupación" +
        "\n5. Buscar vuelo por código" +
        "\n6. Listar vuelos ordenados por ocupación" +
        "\n7. Salir");
    }

    //Agrega un vuelo con los datos
    static void AgregarVuelo()
    {
        Console.Write("Ingrese el código del vuelo: ");
        string codigo = Console.ReadLine();

        Console.Write("Ingrese la fecha y hora de salida (dd/MM/yyyy HH:mm): ");
        DateTime fechaSalida = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

        Console.Write("Ingrese la fecha y hora de llegada (dd/MM/yyyy HH:mm): ");
        DateTime fechaLlegada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

        int resultado = DateTime.Compare(fechaSalida, fechaLlegada);

        if (resultado > 0)
        {
            Console.WriteLine("La fecha de salida es anterior a Fecha de llegada, volve a intentarlo.");
            return;
        }

        Console.Write("Ingrese el nombre del piloto: ");
        string piloto = Console.ReadLine();

        Console.Write("Ingrese el nombre del copiloto: ");
        string copiloto = Console.ReadLine();

        Console.Write("Ingrese la capacidad máxima: ");
        int capacidad = int.Parse(Console.ReadLine());

        Vuelo nuevoVuelo = new Vuelo(codigo, fechaSalida, fechaLlegada, piloto, copiloto, capacidad);
        aerolinea.AgregarVuelo(nuevoVuelo);

        Console.WriteLine("Vuelo agregado con éxito. Presione cualquier tecla para continuar.");
        vuelosCreado = true;
        Console.ReadKey();
    }

    //Registra la cantidad de pasajeros de un vuelo según su código
    static void RegistrarPasajeros()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }
        Console.Write("Ingrese el código del vuelo: ");
        string codigo = Console.ReadLine();

        Vuelo vuelo = aerolinea.BuscarVuelo(codigo);

        if (vuelo != null)
        {
            Console.Write("Ingrese el número de pasajeros a registrar: ");
            int pasajeros = int.Parse(Console.ReadLine());

            if (vuelo.PasajerosRegistrados + pasajeros <= vuelo.CapacidadMaxima)
            {
                vuelo.PasajerosRegistrados += pasajeros;
                Console.WriteLine("Pasajeros registrados con éxito. Presione cualquier tecla para continuar.");
            }
            else
            {
                Console.WriteLine("No se puede registrar más pasajeros que la capacidad máxima. Presione cualquier tecla para continuar.");
            }
        }
        else
        {
            Console.WriteLine("Vuelo no encontrado. Presione cualquier tecla para continuar.");
        }
        Console.ReadKey();
    }

    //Calcula la ocupación media de la flota en porcentaje
    static void CalcularOcupacionMedia()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }
        double ocupacionMedia = aerolinea.CalcularOcupacionMedia();
        Console.WriteLine("La ocupación media de la flota es: " + ocupacionMedia.ToString("F2") + "%"); // F2 indica que se debe mostrar el número con dos decimales.
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    //Identifica y muestra el vuelo que tiene el mayor porcentaje de ocupación.
    static void VueloConMayorOcupacion()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Vuelo vueloMayorOcupacion = aerolinea.ObtenerVueloConMayorOcupacion();
        if (vueloMayorOcupacion != null)
        {
            Console.WriteLine("El vuelo con mayor ocupación es: " + vueloMayorOcupacion.CodigoVuelo + " con un " + 
                vueloMayorOcupacion.CalcularOcupacion().ToString("F2") + "% de ocupación.");
        }
        else
        {
            Console.WriteLine("No hay vuelos registrados.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    //Permite al usuario ingresar el código de un vuelo específico y muestra sus detalles si existe, junto con su porcentaje de ocupación.
    static void BuscarVueloPorCodigo()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }

        Console.Write("Ingrese el código del vuelo: ");
        string codigo = Console.ReadLine();

        Vuelo vuelo = aerolinea.BuscarVuelo(codigo);

        if (vuelo != null)
        {
            Console.WriteLine("Código: " + vuelo.CodigoVuelo +
                  ", salida: " + vuelo.FechaSalida +
                  ", llegada: " + vuelo.FechaLlegada +
                  ", Piloto: " + vuelo.NombrePiloto +
                  ", Copiloto: " + vuelo.NombreCopiloto +
                  ", capacidad: " + vuelo.CapacidadMaxima +
                  ", pasajeros: " + vuelo.PasajerosRegistrados +
                  ", ocupación: " + vuelo.CalcularOcupacion().ToString("F2") + "%");
        }
        else
        {
            Console.WriteLine("Vuelo no encontrado.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    //Muestra todos los vuelos ordenados según su porcentaje de ocupación, de mayor a menor.
    static void ListarVuelosPorOcupacion()
    {
        if (!vuelosCreado)
        {
            Console.WriteLine("Debes crear un vuelo.");
            return;
        }
        List<Vuelo> vuelosOrdenados = aerolinea.ListarVuelosOrdenadosPorOcupacion();
        if (vuelosOrdenados.Count > 0)
        {
            Console.WriteLine("Lista de vuelos ordenados por ocupación:");
            foreach (Vuelo vuelo in vuelosOrdenados)
            {
                Console.WriteLine(vuelo.CodigoVuelo + " - Ocupación: " + vuelo.CalcularOcupacion().ToString("F2") + "%");
            }
        }
        else
        {
            Console.WriteLine("No hay vuelos registrados.");
        }
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }
}