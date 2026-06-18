using Backend.Data;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class HorariosService : IHorariosService
{

    private readonly AppDbContext _context;


    public HorariosService(AppDbContext context)
    {
        _context = context;
    }



    public async Task<List<HorarioDTO>> GetAll()
    {
        return await _context.Horarios
            .Include(h => h.Chofer)
            .Include(h => h.Ruta)
            .Select(h => new HorarioDTO
            {
                IDHorarios = h.IDHorarios,
                RutaId = h.RutaId,
                ChoferId = h.ChoferId,
                HoraSalida = h.HoraSalida,
                CuposIniciales = h.CuposIniciales,
                NombreChofer = h.Chofer.NombreChofer,
                Recorrido = h.Ruta.Recorrido
            })
            .ToListAsync();
    }





    public async Task<Horarios?> GetById(int id)
    {
        return await _context.Horarios
            .Include(h => h.Chofer)
            .FirstOrDefaultAsync(
                h => h.IDHorarios == id);
    }





    public async Task<Horarios> Create(Horarios horario)
    {

        _context.Horarios.Add(horario);

        await _context.SaveChangesAsync();


        return horario;
    }





    public async Task<bool> Update(
        int id,
        Horarios horario)
    {

        var actual = await _context.Horarios
            .FirstOrDefaultAsync(
                h => h.IDHorarios == id);



        if(actual == null)
            return false;




        actual.HoraSalida = horario.HoraSalida;
        actual.ChoferId = horario.ChoferId;
        actual.CuposIniciales = horario.CuposIniciales;



        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> Delete(int id)
    {

        var horario = await _context.Horarios
            .FirstOrDefaultAsync(
                h => h.IDHorarios == id);



        if(horario == null)
            return false;



        _context.Horarios.Remove(horario);


        await _context.SaveChangesAsync();


        return true;
    }

}