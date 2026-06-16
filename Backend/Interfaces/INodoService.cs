using Backend.Models;

namespace Backend.Interfaces;

public interface INodoService
{
    Task<List<Nodos>> GetAll();
    Task<Nodos?> GetById(int id);
    Task<Nodos> Create(Nodos nodo);
    Task<Nodos?> Update(int id, Nodos nodo);
    Task<Nodos?> Delete(int id);
}