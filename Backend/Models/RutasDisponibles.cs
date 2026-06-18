using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class RutasDisponibles
{
    [Key]
    public int IDRuta { get; set; }

    public string Recorrido { get; set; } = string.Empty;

    public string Tipo { get; set; } = string.Empty;

    public int Parada { get; set; }

    public double Costo { get; set; }

    public TimeSpan Tiempo { get; set; }

    public string Trafico { get; set; } = string.Empty;


    [Column("Chofer")]
    public int ChoferId { get; set; }

    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; } = null!;


    public ICollection<Aristas> Aristas { get; set; } = new List<Aristas>();

    public ICollection<RutaAristas> RutaAristas { get; set; } 
        = new List<RutaAristas>();
    public ICollection<HistorialViajes> HistorialViajes { get; set; }
        = new List<HistorialViajes>();  
}