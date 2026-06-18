using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Horarios
{
    [Key]
    public int IDHorarios { get; set; }

    public TimeSpan HoraSalida { get; set; }

    [Column("Chofer")]
    public int ChoferId { get; set; }

    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; } = null!;

    public int CuposIniciales { get; set; }

    [Column("Ruta")]
    public int RutaId { get; set; }

    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles Ruta { get; set; } = null!;

    public ICollection<Reservas> Reservas { get; set; }
        = new List<Reservas>();
}