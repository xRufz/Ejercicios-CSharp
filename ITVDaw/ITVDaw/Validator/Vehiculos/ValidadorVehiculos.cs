using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using ITVDaw.Errors.Common;
using ITVDaw.Errors.Vehiculos;
using ITVDaw.Models;
using ITVDaw.Validator.Common;

namespace ITVDaw.Validator.Vehiculos;

public class ValidadorVehiculos : IValidator<Vehiculo>
{
    public Result<Vehiculo, DomainError> Validar(Vehiculo vehiculo)
    {
        // var PatronDni = @"^\d{8}$";
        var PatronMatricula = @"^\d{4}[BCDFGHJKLMNPRSTVWXYZ]{3}$";
        var Errors = new List<string>();

        if (vehiculo is not Vehiculo Vehiculo)
        {
            Errors.Add("La entidad vehiculo insertada no es valida");
            return Result.Failure<Vehiculo, DomainError>(VehiculosErrors.Validation(Errors));
        }

        if (vehiculo.Cilindrada > 5000 || vehiculo.Cilindrada < 0)
            Errors.Add("La Cilindrada debe estar entre 0 y 5000");

        if (string.IsNullOrWhiteSpace(vehiculo.Marca)) Errors.Add("El campo marca no puede estar en blanco");

        if (string.IsNullOrWhiteSpace(vehiculo.Matricula) || Regex.IsMatch(vehiculo.Matricula, PatronMatricula))
            Errors.Add("El campo matricula no puede estar en blanco, o no ser Letra-Numero [LLLLNNN]");

        return Result.Success<Vehiculo, DomainError>(vehiculo);
    }
}