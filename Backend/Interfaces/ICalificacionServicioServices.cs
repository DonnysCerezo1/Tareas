using Backend.Models;

namespace Backend.Interfaces;

public interface ICalificacionServicioService
{
    Task<IEnumerable<CalificacionServicio>> GetAll();

    Task<CalificacionServicio?> GetById(int id);

    Task<CalificacionServicio> Create(
        CalificacionServicio calificacion);

    Task<bool> Update(
        int id,
        CalificacionServicio calificacion);

    Task<bool> Delete(int id);
}