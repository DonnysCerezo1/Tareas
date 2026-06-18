using Backend.Data;
using Backend.Models;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;


public class ChoferesAutorizadosService : IChoferesAutorizadosService
{

    private readonly AppDbContext _context;


    public ChoferesAutorizadosService(AppDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<ChoferesAutorizados>> GetAll()
    {
        return await _context.ChoferesAutorizados
            .ToListAsync();
    }




    public async Task<ChoferesAutorizados?> GetById(int id)
    {
        return await _context.ChoferesAutorizados
            .FirstOrDefaultAsync(
                c => c.IDChofer == id);
    }





    public async Task<ChoferesAutorizados> Create(
        ChoferesAutorizados chofer)
    {

        _context.ChoferesAutorizados.Add(chofer);

        await _context.SaveChangesAsync();


        return chofer;
    }







    public async Task<bool> Update(
        int id,
        ChoferesAutorizados chofer)
    {

        var actual = await _context.ChoferesAutorizados
            .FirstOrDefaultAsync(
                c => c.IDChofer == id);



        if(actual == null)
            return false;



        actual.NombreChofer = chofer.NombreChofer;
        actual.TelefonoChofer = chofer.TelefonoChofer;
        actual.Cupos = chofer.Cupos;
        actual.EstadoChofer = chofer.EstadoChofer;



        await _context.SaveChangesAsync();


        return true;
    }







    public async Task<bool> Delete(int id)
    {

        var chofer = await _context.ChoferesAutorizados
            .FirstOrDefaultAsync(
                c => c.IDChofer == id);



        if(chofer == null)
            return false;



        _context.ChoferesAutorizados.Remove(chofer);


        await _context.SaveChangesAsync();


        return true;
    }

}