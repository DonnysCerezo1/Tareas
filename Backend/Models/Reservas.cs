using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Reservas
{
    [Key]
    public int IDReserva { get; set; }

    [Column("Ruta")]
    public int RutaId { get; set; }

    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles Ruta { get; set; } = null!;

    [Column("Horario")]
    public int HorarioId { get; set; }

    [ForeignKey(nameof(HorarioId))]
    public Horarios Horario { get; set; } = null!;

    [Column("Chofer")]
    public int ChoferId { get; set; }

    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public ICollection<CalificacionServicio> Calificaciones { get; set; }
        = new List<CalificacionServicio>();
}