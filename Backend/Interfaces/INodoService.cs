using Backend.Models;

namespace Backend.Interfaces;

public interface INodoService
{
    Task<IEnumerable<Nodos>> GetAll();

    Task<Nodos?> GetById(int id);

    Task<Nodos> Create(Nodos nodo);

    Task<bool> Update(int id, Nodos nodo);

    Task<bool> Delete(int id);
}