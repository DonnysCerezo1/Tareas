using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class HistorialViajes
{
    public int IDViajes { get; set; }
    
    [Column ("Estudiante")]
    public int EstudianteId { get; set; }
    
    [ForeignKey(nameof(EstudianteId))]
    
    public Estudiantes Estudiante { get; set; }
    
    [Column("Ruta")]
    public string RutaId { get; set; }
    [ForeignKey(nameof(RutaId))]
    public RutasDisponibles  Ruta { get; set; }
    
    [Column ("Recorrido")]
    
    public int RecorridoId { get; set; }
    [ForeignKey(nameof(RecorridoId))]
    public RutasDisponibles  Recorrido { get; set; }
    
    public DateTime Fecha { get; set; }
    
    public TimeSpan Tiempo { get; set; }
    
    public enum ESTADO
    {
        Completado,
        NoCompletado
    }
    
}