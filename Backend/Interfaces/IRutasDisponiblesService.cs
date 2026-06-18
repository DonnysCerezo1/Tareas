
using Backend.Models;
using Backend.DTO;

namespace Backend.Interfaces;

public interface IRutasDisponiblesService
{
    Task<List<RutasDisponibles>> GetAll();

    Task<RutasDisponibles?> GetById(int id);

    Task<List<ParadaMapaDTO>> GetParadasRuta(int idRuta);
}