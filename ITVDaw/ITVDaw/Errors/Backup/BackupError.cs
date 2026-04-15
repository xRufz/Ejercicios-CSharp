using ITVDaw.Errors.Common;

namespace ITVDaw.Errors.Backup;

public abstract record BackupError(string Message) : DomainError(Message)
{
    public sealed record FileNotFound(string FilePath)
        : BackupError($"No se ha encontrado el fichero de backup: {FilePath}");

    public sealed record InvalidBackupFile(string Details)
        : BackupError($"El archivo no es valido o está corrupto: {Details}");

    public sealed record CreationError(string Details)
        : BackupError($"Error al crear el fichero de backup: {Details}");

    public sealed record RestorationError(string Details)
        : BackupError($"Error al restaurar el fichero debackup: {Details}");

    public sealed record DirectoryError(string Details)
        : BackupError($"Error con el directorio de backup: {Details}");
}

public static class BackupErrors
{
    public static DomainError FileNotFound(string filePath)
    {
        return new BackupError.FileNotFound(filePath);
    }

    public static DomainError InvalidBackupFile(string details)
    {
        return new BackupError.InvalidBackupFile(details);
    }

    public static DomainError CreationError(string details)
    {
        return new BackupError.CreationError(details);
    }

    public static DomainError RestorationError(string details)
    {
        return new BackupError.RestorationError(details);
    }

    public static DomainError DirectoryError(string details)
    {
        return new BackupError.DirectoryError(details);
    }
}