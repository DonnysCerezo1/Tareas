using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class RutasDisponibles
{
    [Key]
    public int IDRuta { get; set; }

    public string Recorrido { get; set; } = string.Empty;

    public int Parada { get; set; }

    public double Costo { get; set; }

    public TimeSpan Tiempo { get; set; }

    [Column("Chofer")]
    public int ChoferId { get; set; }

    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; } = null!;

    public ICollection<Aristas> Traficos { get; set; }
        = new List<Aristas>();

    public ICollection<HistorialViajes> Rutas { get; set; }
        = new List<HistorialViajes>();

    public ICollection<HistorialViajes> Recorridos { get; set; }
        = new List<HistorialViajes>();

    public ICollection<Reservas> Ruta { get; set; }
        = new List<Reservas>();
}