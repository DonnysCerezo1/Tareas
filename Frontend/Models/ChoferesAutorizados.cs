namespace Frontend.Models;

public class ChoferesAutorizados
{
    public int IDChofer { get; set; }
    public string NombreChofer { get; set; } = string.Empty;
    public string TelefonoChofer { get; set; } = string.Empty;
    public int Cupos { get; set; }
    public bool EstadoChofer { get; set; }
}