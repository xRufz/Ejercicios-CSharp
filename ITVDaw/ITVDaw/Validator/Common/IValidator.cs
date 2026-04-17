using CSharpFunctionalExtensions;
using ITVDaw.Errors.Common;

namespace ITVDaw.Validator.Common;

public interface IValidator<T>
{
    Result<T, DomainError> Validar(T Entidad);
}