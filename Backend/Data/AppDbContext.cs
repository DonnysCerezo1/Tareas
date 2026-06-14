using Microsoft.EntityFrameworkCore;
using Backend.Models;
namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Aristas> Aristas { get; set; } = null!;
    public DbSet<CalificacionServicio> CalificacionServicio { get; set; }
    public DbSet<ChoferesAutorizados> ChoferesAutorizados { get; set; }
    public DbSet<Estudiantes> Estudiantes { get; set; }
    public DbSet<HistorialViajes> HistorialViajes { get; set; }
    public DbSet<Horarios> Horarios { get; set; }
    public DbSet<Nodos> Nodos { get; set; }
    public DbSet<Reservas> Reservas { get; set; }
    public DbSet<RutasDisponibles> RutasDisponibles { get; set; }
    public DbSet<Vehiculos> Vehiculos { get; set; }

}