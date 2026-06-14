namespace Backend.Models;

public class Estudiantes
{
    public int IDEst { get; set; }
    public string NombreEst { get; set; }
    public string CedulaEst { get; set; }
    public string CorreoEst { get; set; }
  
    public int EdadEst { get; set; }
    public string TelefonoEst { get; set; }
    
    
    public ICollection<HistorialViajes> HistorialViajes { get; set; }  = new List<HistorialViajes>();
    public ICollection<CalificacionServicio> CalificacionServicio { get; set; } = new List<CalificacionServicio>();
}