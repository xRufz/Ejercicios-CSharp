using ITVDaw.Enums;
using ITVDaw.Models;

namespace ITVDaw.Factory;

public static class VehiculosFactory
{
    public static IEnumerable<Vehiculo> Seed()
    {
        var lista = new List<Vehiculo>();

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Diesel, Cilindrada = 1000, Dni_Propietario = "12345678Z", Marca = "Audi",
            Modelo = "A1", Matricula = "9779GHS"
        });

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Diesel, Cilindrada = 1900, Dni_Propietario = "12345678Z", Marca = "Volkswagen",
            Modelo = "Golf", Matricula = "1234BCN"
        });

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Gasolina, Cilindrada = 1200, Dni_Propietario = "87654321X", Marca = "Ford",
            Modelo = "Focus", Matricula = "5678DFG"
        });

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Hibrido, Cilindrada = 1800, Dni_Propietario = "11223344S", Marca = "Toyota",
            Modelo = "Auris", Matricula = "9012HJK"
        });

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Electrico, Cilindrada = 0, Dni_Propietario = "12345678Z", Marca = "Tesla",
            Modelo = "Model S", Matricula = "3456LMN"
        });

        lista.Add(new Vehiculo
        {
            Id = 0, Motor = Motor.Diesel, Cilindrada = 2000, Dni_Propietario = "55667788M", Marca = "BMW",
            Modelo = "Serie 3", Matricula = "7890PQR"
        });

        lista.Add(new Vehiculo
        {
            Id = 6, Motor = Motor.Gasolina, Cilindrada = 1000, Dni_Propietario = "12345678Z", Marca = "Kia",
            Modelo = "Picanto", Matricula = "2233STV"
        });

        return lista;
    }
}