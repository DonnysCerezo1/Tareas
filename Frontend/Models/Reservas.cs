namespace Frontend.Models;

public enum EstadoReserva
{
    PENDIENTE,
    CONFIRMADO,
    CANCELADO
}

public class Reservas
{
    public int IDReserva { get; set; }

    public int EstudianteId { get; set; }

    public int RutaId { get; set; }

    public int HorarioId { get; set; }

    public int ChoferId { get; set; }

    public DateTime Fecha { get; set; }

    public EstadoReserva Estado { get; set; }
}