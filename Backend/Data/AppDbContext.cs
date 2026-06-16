using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Aristas> Aristas { get; set; } = null!;
    public DbSet<CalificacionServicio> CalificacionServicio { get; set; } = null!;
    public DbSet<ChoferesAutorizados> ChoferesAutorizados { get; set; } = null!;
    public DbSet<Estudiantes> Estudiantes { get; set; } = null!;
    public DbSet<HistorialViajes> HistorialViajes { get; set; } = null!;
    public DbSet<Horarios> Horarios { get; set; } = null!;
    public DbSet<Nodos> Nodos { get; set; } = null!;
    public DbSet<Reservas> Reservas { get; set; } = null!;
    public DbSet<RutasDisponibles> RutasDisponibles { get; set; } = null!;
    public DbSet<Vehiculos> Vehiculos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ==========================
        // ARISTAS -> NODOS
        // ==========================

        modelBuilder.Entity<Aristas>()
            .HasOne(a => a.NodoOrigen)
            .WithMany(n => n.Origen)
            .HasForeignKey(a => a.OrigenId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Aristas>()
            .HasOne(a => a.NodoDestino)
            .WithMany(n => n.Destino)
            .HasForeignKey(a => a.DestinoId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Aristas>()
            .HasOne(a => a.RutaTrafico)
            .WithMany(r => r.Traficos)
            .HasForeignKey(a => a.TraficoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // HISTORIAL VIAJES
        // ==========================

        modelBuilder.Entity<HistorialViajes>()
            .HasOne(h => h.Estudiante)
            .WithMany(e => e.HistorialViajes)
            .HasForeignKey(h => h.EstudianteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HistorialViajes>()
            .HasOne(h => h.Ruta)
            .WithMany(r => r.Rutas)
            .HasForeignKey(h => h.RutaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HistorialViajes>()
            .HasOne(h => h.Recorrido)
            .WithMany(r => r.Recorridos)
            .HasForeignKey(h => h.RecorridoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // RESERVAS
        // ==========================

        modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Ruta)
            .WithMany(rd => rd.Ruta)
            .HasForeignKey(r => r.RutaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Horario)
            .WithMany(h => h.Reservas)
            .HasForeignKey(r => r.HorarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservas>()
            .HasOne(r => r.Chofer)
            .WithMany(c => c.Reservas)
            .HasForeignKey(r => r.ChoferId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // HORARIOS
        // ==========================

        modelBuilder.Entity<Horarios>()
            .HasOne(h => h.Chofer)
            .WithMany(c => c.Horarios)
            .HasForeignKey(h => h.ChoferId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // VEHICULOS
        // ==========================

        modelBuilder.Entity<Vehiculos>()
            .HasOne(v => v.ChoferAsignado)
            .WithMany(c => c.Vehiculos)
            .HasForeignKey(v => v.ChoferAsignadoId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // RUTAS DISPONIBLES
        // ==========================

        modelBuilder.Entity<RutasDisponibles>()
            .HasOne(r => r.Chofer)
            .WithMany(c => c.RutasDisponibles)
            .HasForeignKey(r => r.ChoferId)
            .OnDelete(DeleteBehavior.Restrict);

        // ==========================
        // CALIFICACIONES
        // ==========================

        modelBuilder.Entity<CalificacionServicio>()
            .HasOne(c => c.Reserva)
            .WithMany(r => r.Calificaciones)
            .HasForeignKey(c => c.ReservaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CalificacionServicio>()
            .HasOne(c => c.Estudiante)
            .WithMany(e => e.CalificacionServicio)
            .HasForeignKey(c => c.EstudianteId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}