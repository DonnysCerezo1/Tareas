using Backend.Models;
namespace Backend.Interfaces;

public interface ICalificacionServicio
{
    Task<List<CalificacionServicio> > GetCalificacionServiciosAsync();
    Task<CalificacionServicio> GetCalificacionServicioAsync(int id);

    Task<CalificacionServicio> CreateCalificacionServicioAsync(CalificacionServicio calificacionServicio);
    
    Task<CalificacionServicio> UpdateCalificacionServicioAsync(CalificacionServicio calificacionServicio);
    Task<CalificacionServicio> DeleteCalificacionServicio (int id);
    
    
}