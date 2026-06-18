using Backend.Models;

namespace Backend.Interfaces;

public interface IVehiculoService
{
    Task<List<Vehiculos>> GetAll();
    Task<Vehiculos?> GetById(int id);
    Task<Vehiculos> Create(Vehiculos vehiculo);
    Task<Vehiculos?> Update(int id, Vehiculos vehiculo);
    Task<Vehiculos?> Delete(int id);
}