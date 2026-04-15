using ITVDaw.Enums;

namespace ITVDaw.Models;

public record Vehiculo
{
    public int Id;
    public Motor motor;
    public int Cilindrada { get; init; } = 0;
    public string Dni_Propietario { get; init; } = string.Empty;
    public string Marca { get; init; } = string.Empty;
    public string Matricula { get; init; } = string.Empty;
    public string Modelo { get; init; } = string.Empty;
    public bool isDeleted { get; init; } = false;
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; init; } = DateTime.UtcNow;
}