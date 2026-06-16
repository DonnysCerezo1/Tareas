using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class NodoService : INodoService
{
    private readonly AppDbContext _context;

    public NodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Nodos>> GetAll()
    {
        return await _context.Nodos.ToListAsync();
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

    public async Task<Nodos?> Update(int id, Nodos nodo)
    {
        var existente = await _context.Nodos
            .FirstOrDefaultAsync(n => n.IDNodo == id);

        if (existente == null)
            return null;

        existente.Descripcion = nodo.Descripcion;

        await _context.SaveChangesAsync();

        return existente;
    }

    public async Task<Nodos?> Delete(int id)
    {
        var nodo = await _context.Nodos
            .FirstOrDefaultAsync(n => n.IDNodo == id);

        if (nodo == null)
            return null;

        _context.Nodos.Remove(nodo);

        await _context.SaveChangesAsync();

        return nodo;
    }
}