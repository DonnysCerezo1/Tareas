using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class AristaService(AppDbContext context) : IAristaService
{
    
    
    public async Task<List<Aristas>> GetAll()
    {
        return await context.Aristas
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .AsNoTracking()
            .ToListAsync();
    }  

    public async Task<List<Aristas>> GetParadasRuta(int idRuta)
    {
        return await context.Aristas
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .Where(a => a.Ruta == idRuta)
            .ToListAsync();
    }

    public async Task<Aristas?> GetById(int id)
    {
        return await context.Aristas
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .FirstOrDefaultAsync(a => a.IDAristas == id);
    }



    public async Task<Aristas> Create(Aristas arista)
    {
        context.Aristas.Add(arista);

        await context.SaveChangesAsync();

        return arista;
    }



    public async Task<Aristas?> Update(int id, Aristas arista)
    {
        var existente = await context.Aristas
            .FirstOrDefaultAsync(a => a.IDAristas == id);


        if (existente == null)
            return null;


        existente.Origen = arista.Origen;
        existente.Destino = arista.Destino;
        existente.Tiempo = arista.Tiempo;
        existente.Costo = arista.Costo;

        // FK hacia RutasDisponibles
        existente.Ruta = arista.Ruta;

        existente.Distancia = arista.Distancia;


        await context.SaveChangesAsync();


        return existente;
    }



    public async Task<Aristas?> Delete(int id)
    {
        var arista = await context.Aristas
            .FirstOrDefaultAsync(a => a.IDAristas == id);


        if (arista == null)
            return null;


        context.Aristas.Remove(arista);

        await context.SaveChangesAsync();


        return arista;
    }
}