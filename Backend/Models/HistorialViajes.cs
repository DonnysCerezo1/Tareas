using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class HistorialViajes
{
    [Key]
    public int IDViajes { get; set; }

    [Column("Estudiante")]
    public int EstudianteId { get; set; }

    [ForeignKey(nameof(EstudianteId))]
    public Estudiantes Estudiante { get; set; } = null!;

    [Column("Ruta")]
    public int RutaId { get; set; }

    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles Ruta { get; set; } = null!;

    [Column("Recorrido")]
    public int RecorridoId { get; set; }

    [ForeignKey(nameof(RecorridoId))]
    public RutasDisponibles Recorrido { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public TimeSpan Tiempo { get; set; }
}