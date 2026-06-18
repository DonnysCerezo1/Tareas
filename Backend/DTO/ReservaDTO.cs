namespace Backend.DTO;

public class ReservaDTO
{
    public int IDReserva { get; set; }


    public int EstudianteId { get; set; }

    public string NombreEstudiante { get; set; } = "";


    public int RutaId { get; set; }

    public string Recorrido { get; set; } = "";


    public int HorarioId { get; set; }


    public int ChoferId { get; set; }

    public string NombreChofer { get; set; } = "";


    public DateTime Fecha { get; set; }


    public string Estado { get; set; } = "";
}