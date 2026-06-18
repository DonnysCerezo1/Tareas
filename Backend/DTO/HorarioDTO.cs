namespace Backend.DTO;

public class HorarioDTO
{
    public int IDHorarios { get; set; }

    public int RutaId { get; set; }

    public int ChoferId { get; set; }

    public TimeSpan HoraSalida { get; set; }

    public int CuposIniciales { get; set; }

    public string NombreChofer { get; set; } = "";

    public string Recorrido { get; set; } = "";
}