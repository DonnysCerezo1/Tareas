using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Aristas
{
    [Key]
    public int IDAristas { get; set; }

    public int Origen { get; set; }

    public int Destino { get; set; }
    
    public TimeSpan Tiempo { get; set; }
    
    public double Costo { get; set; }
    
    public int Trafico { get; set; } 

    public double Distancia { get; set; }
    
    public int? Ruta { get; set; }


    // Relaciones

    [ForeignKey("Origen")]
    public Nodos NodoOrigen { get; set; } = null!;


    [ForeignKey("Destino")]
    public Nodos NodoDestino { get; set; } = null!;


    [ForeignKey("Ruta")]
    public RutasDisponibles? RutaDisponible { get; set; } = null!;
    public ICollection<RutaAristas> RutaAristas { get; set; } = new List<RutaAristas>();
    
}