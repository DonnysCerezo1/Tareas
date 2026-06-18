using Backend.Models;

namespace Backend.Interfaces;

public interface IHistorialViajesService
{
    Task<IEnumerable<HistorialViajes>> GetAll();

    Task<HistorialViajes?> GetById(int id);

    Task<HistorialViajes> Create(HistorialViajes historial);

    Task<bool> Update(int id, HistorialViajes historial);

    Task<bool> Delete(int id);
}