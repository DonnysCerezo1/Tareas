using Backend.Data;
using Backend.DTO;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Services;


public class ReservasService : IReservasService
{

    private readonly AppDbContext _context;


    public ReservasService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Nodos>> GetParadasRuta(int idRuta)
    {
        var aristas = await _context.Aristas
            .Where(a => a.Ruta == idRuta)
            .Include(a => a.NodoOrigen)
            .Include(a => a.NodoDestino)
            .ToListAsync();


        var nodos = new List<Nodos>();


        foreach (var arista in aristas)
        {
            if (!nodos.Any(n => n.IDNodo == arista.NodoOrigen.IDNodo))
            {
                nodos.Add(arista.NodoOrigen);
            }


            if (!nodos.Any(n => n.IDNodo == arista.NodoDestino.IDNodo))
            {
                nodos.Add(arista.NodoDestino);
            }
        }


        return nodos;
    }
    public async Task<List<ReservaDTO>> GetAll()
    {
        return await _context.Reservas
            .Include(r => r.Ruta)
            .Include(r => r.Chofer)
            .Include(r => r.Estudiante)
            .Select(r => new ReservaDTO
            {
                IDReserva = r.IDReserva,

                EstudianteId = r.EstudianteId,

                RutaId = r.RutaId,

                HorarioId = r.HorarioId,

                ChoferId = r.ChoferId,


                Recorrido = r.Ruta.Recorrido,

                NombreChofer = r.Chofer.NombreChofer,


                Fecha = r.Fecha,

                Estado = r.Estado.ToString()
            })
            .ToListAsync();
    }




    public async Task<List<ReservaDTO>> GetMisReservas(int estudianteId)
    {
        if (_context.Reservas != null)
            return await _context.Reservas
                .Where(r => r.EstudianteId == estudianteId)
                .Include(r => r.Ruta)
                .Include(r => r.Chofer)
                .Select(r => new ReservaDTO
                {
                    IDReserva = r.IDReserva,

                    RutaId = r.RutaId,

                    Recorrido = r.Ruta.Recorrido,


                    ChoferId = r.ChoferId,

                    NombreChofer = r.Chofer.NombreChofer,


                    Fecha = r.Fecha,


                    Estado = r.Estado.ToString()
                })
                .ToListAsync();
        return null!;
    }





    public async Task<Reservas> Create(Reservas reserva)
    {
        Console.WriteLine("ENTRO AL CREATE");

        Console.WriteLine($"Ruta: {reserva.RutaId}");
        Console.WriteLine($"Horario: {reserva.HorarioId}");
        Console.WriteLine($"Chofer: {reserva.ChoferId}");
        Console.WriteLine($"Estudiante: {reserva.EstudianteId}");

        _context.Reservas.Add(reserva);

        await _context.SaveChangesAsync();

        Console.WriteLine($"GUARDADA ID {reserva.IDReserva}");

        return reserva;
    }





    public async Task<bool> Delete(int id)
    {
        {
            var reserva = await _context.Reservas
                .FirstOrDefaultAsync(r => r.IDReserva == id);


            if(reserva == null)
                return false;


            _context.Reservas.Remove(reserva);
        }


        await _context.SaveChangesAsync();


        return true;
    }

}