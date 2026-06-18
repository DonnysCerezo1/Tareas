using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Interfaces;
namespace Backend.Services;

public class NodoService : INodoService
{

    private readonly AppDbContext _context;


    public NodoService(AppDbContext context)
    {
        _context = context;
    }



    public async Task<IEnumerable<Nodos>> GetAll()
    {
        return await _context.Nodos
            .ToListAsync();
    }




    public async Task<Nodos?> GetById(int id)
    {
        return await _context.Nodos
            .FirstOrDefaultAsync(n => n.IDNodo == id);
    }




    public async Task<Nodos> Create(Nodos nodo)
    {

        _context.Nodos.Add(nodo);

        await _context.SaveChangesAsync();


        return nodo;
    }





    public async Task<bool> Update(int id, Nodos nodo)
    {

        var actual = await _context.Nodos
            .FirstOrDefaultAsync(n => n.IDNodo == id);



        if(actual == null)
            return false;



        actual.Lugar = nodo.Lugar;
        actual.Descripcion = nodo.Descripcion;



        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> Delete(int id)
    {

        var nodo = await _context.Nodos
            .FirstOrDefaultAsync(n => n.IDNodo == id);



        if(nodo == null)
            return false;



        _context.Nodos.Remove(nodo);


        await _context.SaveChangesAsync();


        return true;
    }

}