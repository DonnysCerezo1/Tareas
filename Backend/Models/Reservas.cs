using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Backend.Models;

public enum EstadoReserva
{
    PENDIENTE,
    CONFIRMADO,
    CANCELADO
}

public class Reservas
{
    [Key]
    public int IDReserva { get; set; }

    [Column("Estudiante")]
    public int EstudianteId { get; set; }

    [ForeignKey(nameof(EstudianteId))]
    [ValidateNever]
    public Estudiantes? Estudiante { get; set; }

    [Column("Ruta")]
    public int RutaId { get; set; }

    [ForeignKey(nameof(RutaId))]
    [ValidateNever]
    public RutasDisponibles? Ruta { get; set; }

    [Column("Horario")]
    public int HorarioId { get; set; }

    [ForeignKey(nameof(HorarioId))]
    [ValidateNever]
    public Horarios? Horario { get; set; }

    [Column("Chofer")]
    public int ChoferId { get; set; }

    [ForeignKey(nameof(ChoferId))]
    [ValidateNever]
    public ChoferesAutorizados? Chofer { get; set; }

    public DateTime Fecha { get; set; }

    public EstadoReserva Estado { get; set; }
}