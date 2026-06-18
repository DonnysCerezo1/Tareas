using Backend.Data;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class RutasDisponiblesService : IRutasDisponiblesService
{

    private readonly AppDbContext _context;
    
    public RutasDisponiblesService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<ParadaMapaDTO>> GetParadasRuta(int idRuta)
    {
        var aristas = await _context.RutaAristas
            .Where(x => x.RutaId == idRuta)
            .Include(x => x.Arista)
            .ThenInclude(a => a.NodoOrigen)
            .Include(x => x.Arista)
            .ThenInclude(a => a.NodoDestino)
            .OrderBy(x => x.Orden)
            .ToListAsync();


        var resultado = new List<ParadaMapaDTO>();


        foreach (var item in aristas)
        {

            var origen = item.Arista.NodoOrigen;


            if(resultado.Count == 0 ||
               resultado.Last().ID != origen.IDNodo)
            {
                resultado.Add(new ParadaMapaDTO
                {
                    ID = origen.IDNodo,
                    Lugar = origen.Lugar,
                    Latitud = origen.Latitud,
                    Longitud = origen.Longitud
                });
            }



            var destino = item.Arista.NodoDestino;


            if(resultado.Count == 0 ||
               resultado.Last().ID != destino.IDNodo)
            {
                resultado.Add(new ParadaMapaDTO
                {
                    ID = destino.IDNodo,
                    Lugar = destino.Lugar,
                    Latitud = destino.Latitud,
                    Longitud = destino.Longitud
                });
            }

        }
        Console.WriteLine($"Ruta recibida: {idRuta}");
        Console.WriteLine($"Cantidad aristas: {aristas.Count}");

        foreach(var a in aristas)
        {
            Console.WriteLine(
                $"{a.Arista.IDAristas}: " +
                $"{a.Arista.NodoOrigen.Lugar} -> " +
                $"{a.Arista.NodoDestino.Lugar}"
            );
        }

        return resultado;
    }
    public async Task<RutasDisponibles?> GetById(int idRuta)
    {
        return await _context.RutasDisponibles
            .FirstOrDefaultAsync(r => r.IDRuta == idRuta);
    }

    public async Task<List<RutasDisponibles>> GetAll()
    {
        return await _context.RutasDisponibles
            .Include(r => r.Chofer)
            .ToListAsync();
    }

}