# Trabajo_Practico4

# Sistema para gestionar la ocupación y las estadísticas de los vuelos.

## Integrantes del Equipo
- **Integrante 1**: Giaquinta, Anahid Belen
- **Integrante 2**: Previgliano, Santiago

## Descripción
Este proyecto es un sistema para gestionar la ocupación y estadisticas de los vuelos que permite a los usuarios agregar un vuelo, registrar la cantidad de pasajeros en un vuelo, calcular ocupación media, identificar el vuelo con mayor ocupación, buscar vuelo por código y listar vuelos ordenados por ocupación.

## Funcionalidades de la clase Program
- **MostrarMenu**: Muestra el menu con las opciones de lo que se puede realizar.
- **AgregarVuelo**: Agrega un vuelo con fecha, hora de salida y llegada, nombre del piloto, nombre del copiloto y la cantidad maxima de pasajeros.
- **RegistrarPasajeros**: Permite ingresar el número de pasajeros que subieron a un vuelo, según su código.
- **CalcularOcupacionMedia**:  Calcula el promedio de ocupación de todos los vuelos registrados.
- **Mostrar cantidad de asientos**: Indica cuántos asientos están disponibles y ocupados.
- **VueloConMayorOcupacion**: Identifica y muestra el vuelo que tiene el mayor porcentaje de ocupación.
- **BuscarVueloPorCodigo**: Permite al usuario ingresar el código de un vuelo específico y muestra sus detalles, junto con su porcentaje de ocupación.
- **ListarVuelosPorOcupacion**: Muestra todos los vuelos ordenados según su porcentaje de ocupación, de mayor a menor.

## Funcionalidades de la clase Vuelo
- **Vuelo**: Inicializa un vuelo según los datos que se ingresen desde Program.cs
- **CalcularOcupacion**: Calcula porcentaje de ocupación.

## Funcionalidades de la clase Aerolinea
- **AgregarVuelo**: Agrega un vuelo.
- **BuscarVuelo**: Devuelve el vuelo si existe.
- **CalcularOcupacionMedia**: Retorna la ocupación media de vuelos.
- **ObtenerVueloConMayorOcupacion**: Devuelve el vuelo con mayor ocupación.
- **ListarVuelosOrdenadosPorOcupacion**: Devuelve los vuelos ordenados de mayor a menor según su ocupación.
- **ObtenerVuelos**: Retorna a vuelo.

## Tecnologías Utilizadas
- **C#**
- **.NET Framework**
- **Visual Studio**

