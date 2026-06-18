using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class HistorialViajes
{
    [Key]
    public int IDHisViajes { get; set; }


    // FK Estudiante
    [Column("Estudiante")]
    public int EstudianteId { get; set; }

    [ForeignKey(nameof(EstudianteId))]
    public Estudiantes Estudiante { get; set; } = null!;



    // FK Ruta
    [Column("Ruta")]
    public int RutaId { get; set; }

    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles Ruta { get; set; } = null!;



    // Campo normal
    public string Recorrido { get; set; } = string.Empty;


    public DateTime Fecha { get; set; }


    public TimeSpan Tiempo { get; set; }


    public string ESTADO { get; set; } = string.Empty;
}