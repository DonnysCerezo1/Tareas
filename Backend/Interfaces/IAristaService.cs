using Backend.Models;

namespace Backend.Interfaces;

public interface IAristaService
{
    Task<List<Aristas>> GetAll();
    Task<Aristas?> GetById(int id);
    Task<Aristas> Create(Aristas aristas);
    Task<Aristas> Update(int id, Aristas aristas);
    Task<Aristas> Delete(int id);
}