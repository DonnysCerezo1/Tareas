using System.ComponentModel.DataAnnotations;
using Backend.Models;

public class Estudiantes
{
    [Key]
    public int IDEst { get; set; }

    public string NombreEst { get; set; } = string.Empty;
    public string CedulaEst { get; set; } = string.Empty;
    public string CorreoEst { get; set; } = string.Empty;
    public int EdadEst { get; set; }
    public string TelefonoEst { get; set; } = string.Empty;

    public ICollection<HistorialViajes> HistorialViajes { get; set; }
        = new List<HistorialViajes>();

    public ICollection<CalificacionServicio> CalificacionServicio { get; set; }
        = new List<CalificacionServicio>();
}