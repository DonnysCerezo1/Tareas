using Backend.Data;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class EstudianteService : IEstudianteService
{
    private readonly AppDbContext _context;

    public EstudianteService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Estudiantes>> GetAll()
    {
        return await _context.Estudiantes
            .ToListAsync();
    }


    public async Task<Estudiantes?> GetById(int id)
    {
        return await _context.Estudiantes
            .FirstOrDefaultAsync(e => e.IDEst == id);
    }


    public async Task<Estudiantes> Create(Estudiantes estudiante)
    {
        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync();

        return estudiante;
    }


    public async Task<bool> Update(int id, Estudiantes estudiante)
    {
        var actual = await _context.Estudiantes
            .FirstOrDefaultAsync(e => e.IDEst == id);


        if(actual == null)
            return false;


        actual.NombreEst = estudiante.NombreEst;
        actual.CedulaEst = estudiante.CedulaEst;
        actual.CorreoEst = estudiante.CorreoEst;
        actual.EdadEst = estudiante.EdadEst;
        actual.TelefonoEst = estudiante.TelefonoEst;


        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> Delete(int id)
    {
        var estudiante = await _context.Estudiantes
            .FirstOrDefaultAsync(e => e.IDEst == id);


        if(estudiante == null)
            return false;


        _context.Estudiantes.Remove(estudiante);

        await _context.SaveChangesAsync();

        return true;
    }
}