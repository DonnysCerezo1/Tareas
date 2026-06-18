using Backend.DTO;
using Backend.Models;

namespace Backend.Interfaces;

public interface IHorariosService
{
    Task<List<HorarioDTO>> GetAll();

    Task<Horarios?> GetById(int id);

    Task<Horarios> Create(Horarios horario);

    Task<bool> Update(int id, Horarios horario);

    Task<bool> Delete(int id);
}