using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Services;

public class AristaService : IAristaService
{
    private readonly AppDbContext _context;

    public AristaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Aristas>> GetAll()
    {
        return await _context.Aristas
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .Include(a => a.RutaTrafico)
            .ToListAsync();
    }
    
    public async Task<Aristas?> GetById(int id)
    {
        return await _context.Aristas
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .Include(a => a.RutaTrafico)
            .FirstOrDefaultAsync(a => a.IDAristas == id);
        
    }

    public async Task<Aristas?> Create()
    {
        return new Aristas();
    }
    
    public Task<Aristas> Create(Aristas aristas)
    {
        throw new NotImplementedException();
    }

    public Task<Aristas> Update(int id, Aristas aristas)
    {
        throw new NotImplementedException();
    }

    public Task<Aristas> Delete(int id)
    {
        throw new NotImplementedException();
    }
}