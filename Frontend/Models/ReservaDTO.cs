namespace Frontend.Models;

public class ReservaDTO
{
    public int IDReserva { get; set; }

    public string Recorrido { get; set; } = "";

    public string NombreChofer { get; set; } = "";

    public DateTime Fecha { get; set; }

    public string Estado { get; set; } = "";
}