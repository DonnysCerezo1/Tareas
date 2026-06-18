using Backend.Models;

namespace Backend.Services.Interfaces;

public interface IEstudianteService
{
    Task<IEnumerable<Estudiantes>> GetAll();
    Task<Estudiantes?> GetById(int id);
    Task<Estudiantes> Create(Estudiantes estudiante);
    Task<bool> Update(int id, Estudiantes estudiante);
    Task<bool> Delete(int id);
}