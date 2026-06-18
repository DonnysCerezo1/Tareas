using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CalificacionServicioService 
    : ICalificacionServicioService
{

    private readonly AppDbContext _context;


    public CalificacionServicioService(AppDbContext context)
    {
        _context = context;
    }




    public async Task<IEnumerable<CalificacionServicio>> GetAll()
    {
        return await _context.CalificacionServicio

            .Include(c => c.Reserva)

            .Include(c => c.Estudiante)

            .ToListAsync();
    }





    public async Task<CalificacionServicio?> GetById(int id)
    {
        return await _context.CalificacionServicio

            .Include(c => c.Reserva)

            .Include(c => c.Estudiante)

            .FirstOrDefaultAsync(
                c => c.IDCalificacion == id);
    }





    public async Task<CalificacionServicio> Create(
        CalificacionServicio calificacion)
    {

        _context.CalificacionServicio.Add(calificacion);


        await _context.SaveChangesAsync();


        return calificacion;
    }





    public async Task<bool> Update(
        int id,
        CalificacionServicio calificacion)
    {

        var actual = await _context.CalificacionServicio

            .FirstOrDefaultAsync(
                c => c.IDCalificacion == id);



        if(actual == null)
            return false;



        actual.ReservaId = calificacion.ReservaId;

        actual.EstudianteId = calificacion.EstudianteId;

        actual.Puntualidad = calificacion.Puntualidad;

        actual.Seguridad = calificacion.Seguridad;

        actual.Comodidad = calificacion.Comodidad;

        actual.Comentario = calificacion.Comentario;



        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> Delete(int id)
    {

        var calificacion = await _context.CalificacionServicio

            .FirstOrDefaultAsync(
                c => c.IDCalificacion == id);



        if(calificacion == null)
            return false;



        _context.CalificacionServicio.Remove(calificacion);


        await _context.SaveChangesAsync();


        return true;
    }

}