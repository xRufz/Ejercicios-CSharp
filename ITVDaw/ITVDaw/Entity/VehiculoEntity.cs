using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITVDaw.Enums;

namespace ITVDaw.Entity;

/// <summary>
///     Entidad de la base de datos para vehiculo
/// </summary>
[Table("VehiculoEntity")]
public class VehiculoEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(5)] public string Cilindrada { get; set; }

    [Required] [MaxLength(9)] public string Dni_Propietario { get; set; }

    public string Marca { get; set; }

    [Required] [MaxLength(7)] public string Matricula { get; set; }

    [Required] [MaxLength(10)] public string Modelo { get; set; }

    [Required] [MaxLength] public Motor Motor { get; set; }

    [Column(TypeName = "datetime2")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column(TypeName = "datetime2")] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; } = false;
}