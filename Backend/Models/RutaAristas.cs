using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class RutaAristas
{
    [Key]
    public int ID { get; set; }


    public int RutaId { get; set; }

    public int AristaId { get; set; }

    public int Orden { get; set; }


    public RutasDisponibles Ruta { get; set; } = null!;

    public Aristas Arista { get; set; } = null!;
}