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
    public DbSet<RutasDisponibles> RutasDisponibles { get; set; } = null!;
    public DbSet<Vehiculos> Vehiculos { get; set; } = null!;
    public DbSet<Usuarios> Usuarios { get; set; } = null!;
    public DbSet<Reservas> Reservas { get; set; } = null!;
    public DbSet<RutaAristas> RutaAristas { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // ==========================
        // ARISTAS
        // ==========================

        modelBuilder.Entity<Aristas>()
            .HasKey(a => a.IDAristas);

        modelBuilder.Entity<Reservas>()
            .Property(r => r.Estado)
            .HasConversion<string>();
        // Arista -> Nodo Origen

        modelBuilder.Entity<Aristas>()
            .HasOne(a => a.NodoOrigen)
            .WithMany(n => n.Origen)
            .HasForeignKey(a => a.Origen)
            .OnDelete(DeleteBehavior.Restrict);



        // Arista -> Nodo Destino

        modelBuilder.Entity<Aristas>()
            .HasOne(a => a.NodoDestino)
            .WithMany(n => n.Destino)
            .HasForeignKey(a => a.Destino)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // RUTA ARISTAS (TABLA INTERMEDIA)
        // ==========================

        modelBuilder.Entity<RutaAristas>()
            .HasKey(ra => ra.ID);


        modelBuilder.Entity<RutaAristas>()
            .HasOne(ra => ra.Ruta)
            .WithMany(r => r.RutaAristas)
            .HasForeignKey(ra => ra.RutaId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<RutaAristas>()
            .HasOne(ra => ra.Arista)
            .WithMany(a => a.RutaAristas)
            .HasForeignKey(ra => ra.AristaId)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // HORARIOS -> CHOFER
        // ==========================
        
        modelBuilder.Entity<Horarios>()
            .HasOne(h => h.Ruta)
            .WithMany()
            .HasForeignKey(h => h.RutaId)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // VEHICULOS -> CHOFER
        // ==========================

        modelBuilder.Entity<Vehiculos>()
            .HasOne(v => v.ChoferAsignado)
            .WithMany(c => c.Vehiculos)
            .HasForeignKey(v => v.ChoferAsignadoId)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // RUTAS -> CHOFER
        // ==========================

        modelBuilder.Entity<RutasDisponibles>()
            .HasOne(r => r.Chofer)
            .WithMany(c => c.RutasDisponibles)
            .HasForeignKey(r => r.ChoferId)
            .OnDelete(DeleteBehavior.Restrict);



        // ==========================
        // CALIFICACIONES -> ESTUDIANTE
        // ==========================

        modelBuilder.Entity<CalificacionServicio>()
            .HasOne(c => c.Estudiante)
            .WithMany(e => e.CalificacionServicio)
            .HasForeignKey(c => c.EstudianteId)
            .OnDelete(DeleteBehavior.Restrict);



        base.OnModelCreating(modelBuilder);
    }
}