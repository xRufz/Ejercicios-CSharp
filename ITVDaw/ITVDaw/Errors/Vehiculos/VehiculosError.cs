using ITVDaw.Errors.Common;

namespace ITVDaw.Errors.Vehiculos;

public abstract record VehiculosError(string Message)  : DomainError(Message)
{
    public sealed record NotFound(string Id)
        : VehiculosError($"No se ha encontrado ningun vehiculo con el identificador: {Id}");

    public sealed record Validation(IEnumerable<string> Errors)
        : VehiculosError("Se han detectado errores de validación en la entidad.");

    public sealed record AlreadyExists(string Dni)
        : VehiculosError($"Conflicto de integridad: El DNI {Dni} ya está registrado en el sistema.");

    public sealed record StorageError(string Details)
        : VehiculosError($"Error de almacenamiento: {Details}");
}

public static class VehiculosErrors
{
    public static DomainError NotFound(string Id) => new VehiculosError.NotFound(Id);
    public static DomainError Validation(IEnumerable<string> errors) => new VehiculosError.Validation(errors);
    public static DomainError AlreadyExists(string dni) => new VehiculosError.AlreadyExists(dni);
    public static DomainError StorageError(string details) => new VehiculosError.StorageError(details);
}