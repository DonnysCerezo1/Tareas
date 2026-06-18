using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class HistorialViajesService : IHistorialViajesService
{

    private readonly AppDbContext _context;


    public HistorialViajesService(AppDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<HistorialViajes>> GetAll()
    {
        return await _context.HistorialViajes

            .Include(h => h.Estudiante)

            .Include(h => h.Ruta)

            .ToListAsync();
    }





    public async Task<HistorialViajes?> GetById(int id)
    {
        return await _context.HistorialViajes

            .Include(h => h.Estudiante)

            .Include(h => h.Ruta)

            .FirstOrDefaultAsync(
                h => h.IDHisViajes == id);
    }





    public async Task<HistorialViajes> Create(
        HistorialViajes historial)
    {

        _context.HistorialViajes.Add(historial);


        await _context.SaveChangesAsync();


        return historial;
    }





    public async Task<bool> Update(
        int id,
        HistorialViajes historial)
    {

        var actual = await _context.HistorialViajes

            .FirstOrDefaultAsync(
                h => h.IDHisViajes == id);



        if(actual == null)
            return false;



        actual.EstudianteId = historial.EstudianteId;

        actual.Ruta = historial.Ruta;

        actual.Recorrido = historial.Recorrido;

        actual.Fecha = historial.Fecha;

        actual.Tiempo = historial.Tiempo;

        actual.ESTADO = historial.ESTADO;



        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> Delete(int id)
    {

        var historial = await _context.HistorialViajes

            .FirstOrDefaultAsync(
                h => h.IDHisViajes == id);



        if(historial == null)
            return false;



        _context.HistorialViajes.Remove(historial);


        await _context.SaveChangesAsync();


        return true;
    }

}