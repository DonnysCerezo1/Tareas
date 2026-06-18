namespace Backend.DTO;

public class RutaDisponibleDTO
{
    public int IDRuta { get; set; }

    public string Recorrido { get; set; } = "";

    public string Tipo { get; set; } = "";

    public int Parada { get; set; }

    public double Costo { get; set; }

    public TimeSpan Tiempo { get; set; }

    public string Trafico { get; set; } = "";

    public int ChoferId { get; set; }

    public string NombreChofer { get; set; } = "";
}