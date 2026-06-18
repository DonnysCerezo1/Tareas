using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;


public class VehiculoService : IVehiculoService
{

    private readonly AppDbContext _context;


    public VehiculoService(AppDbContext context)
    {
        _context = context;
    }



    public async Task<List<Vehiculos>> GetAll()
    {
        return await _context.Vehiculos
            .ToListAsync();
    }



    public async Task<Vehiculos?> GetById(int id)
    {
        return await _context.Vehiculos
            .Include(v => v.ChoferAsignado)
            .FirstOrDefaultAsync(v => v.IDVehiculos == id);
    }



    public async Task<Vehiculos> Create(Vehiculos vehiculo)
    {
        _context.Vehiculos.Add(vehiculo);

        await _context.SaveChangesAsync();

        return vehiculo;
    }



    public async Task<Vehiculos?> Update(int id, Vehiculos vehiculo)
    {
        var existente = await _context.Vehiculos
            .FindAsync(id);


        if (existente == null)
            return null;


        existente.TipoVehiculo = vehiculo.TipoVehiculo;
        existente.PlacaVehiculo = vehiculo.PlacaVehiculo;
        existente.CapacidadVehiculo = vehiculo.CapacidadVehiculo;
        existente.ChoferAsignadoId = vehiculo.ChoferAsignadoId;
        existente.EstadoVehiculo = vehiculo.EstadoVehiculo;


        await _context.SaveChangesAsync();

        return existente;
    }



    public async Task<Vehiculos?> Delete(int id)
    {
        var vehiculo = await _context.Vehiculos
            .FindAsync(id);


        if (vehiculo == null)
            return null;


        _context.Vehiculos.Remove(vehiculo);

        await _context.SaveChangesAsync();


        return vehiculo;
    }

}