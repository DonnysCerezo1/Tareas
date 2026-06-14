using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class CalificacionServicio
{
    public int IDCalificacion { get; set; }
    
    [Column ("Reserva")]
    public int ReservaId {  get; set; }
    
    [ForeignKey(nameof(ReservaId))]
    public Reservas Reserva { get; set; }
    
    [Column ("Estudiante")]
    public int EstudianteId { get; set; }
    
    [ForeignKey(nameof(EstudianteId))]
    public Estudiantes Estudiante { get; set; }
    public int Puntualidad { get; set; }
    public int Seguridad  { get; set; }
    public int Comodidad  { get; set; }
    public string Comentario { get; set; }
    
}