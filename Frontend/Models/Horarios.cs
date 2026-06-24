namespace Frontend.Models;

public class Horarios
{
    public int IDHorarios { get; set; }

    public TimeSpan HoraSalida { get; set; }

    public int ChoferId { get; set; }

    public int CuposIniciales { get; set; }

    public ChoferesAutorizados? Chofer { get; set; }
}