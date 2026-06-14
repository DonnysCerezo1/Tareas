using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Reservas
{
    public int IDReserva { get; set; }
    
    [Column ("Ruta")]
    public int RutaId {get; set;}
    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles  Ruta { get; set; }
    
    [Column ("Horario")]
    public int HorarioId {get; set;}
    
    [ForeignKey(nameof(HorarioId))]
    
    public Horarios Horario { get; set; }
    
    [Column ("Chofer")]
    public int ChoferId {get; set;}
    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados Chofer { get; set; }
    
    public TimeSpan Fecha { get; set; }
    
    public enum Estado
    {
        CONFIRMADO,
        PENDIENTE,
        CANCELADO
    }
    
    public ICollection<CalificacionServicio>  Calificaciones { get; set; } = new List<CalificacionServicio>();
    
}