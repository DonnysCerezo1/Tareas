using Backend.DTO;
using Backend.Models;

namespace Backend.Interfaces;

public interface IReservasService
{

    Task<List<ReservaDTO>> GetAll();


    Task<List<ReservaDTO>> GetMisReservas(int estudianteId);


    Task<Reservas> Create(Reservas reserva);


    Task<bool> Delete(int id);

}