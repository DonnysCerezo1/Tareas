using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Aristas
{
    [Key] public int IDAristas { get; set; }

    [Column("Origen")] public int OrigenId { get; set; }

    [ForeignKey(nameof(OrigenId))] public Nodos NodoOrigen { get; set; } = null!;

    [Column("Destino")] public int DestinoId { get; set; }

    [ForeignKey(nameof(DestinoId))] public Nodos NodoDestino { get; set; } = null!;

    public TimeSpan Tiempo { get; set; }

    public double Costo { get; set; }

    [Column("Trafico")] public int TraficoId { get; set; }

    [ForeignKey(nameof(TraficoId))] public RutasDisponibles RutaTrafico { get; set; } = null!;

    public double Distancia { get; set; }
}