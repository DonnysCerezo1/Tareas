using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class RutasDisponibles
{
    public int IDRuta  { get; set; }
    
    public string Recorrido  { get; set; }
    
    public enum Tipo
    {
        Directa,
        NoDirecta
    }
    
    public int Parada { get; set; }
    
    public double Costo { get; set; }
    
    public TimeSpan Tiempo  { get; set; }
    
    public enum Trafico
    {
        BAJO,
        MEDIO,
        ALTO
    }
    
    [Column ("Chofer")]
    public int ChoferId { get; set; }
    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; }
    
    public ICollection<Aristas> Traficos { get; set; } = new List<Aristas>();
    
    public ICollection<HistorialViajes> Rutas { get; set; } = new List<HistorialViajes>();
    
    public ICollection<HistorialViajes> Recorridos { get; set; } = new List<HistorialViajes>();
    
    public ICollection<Reservas> Ruta { get; set; } = new List<Reservas>();
    
}