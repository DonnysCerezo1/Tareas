using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IChoferesAutorizadosService
{
    Task<IEnumerable<ChoferesAutorizados>> GetAll();
    Task<ChoferesAutorizados?> GetById(int id);
    Task<ChoferesAutorizados> Create(ChoferesAutorizados chofer);
    Task<bool> Update(int id, ChoferesAutorizados chofer);
    Task<bool> Delete(int id);
}