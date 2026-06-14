namespace Backend.Models;

public class ChoferesAutorizados
{
    public int IDChofer { get; set; }
    
    public string NombreChofer { get; set; }
    
    public string TelefonoChofer { get; set; }
    public int Cupos { get; set; }
    
    public bool EstadoChofer { get; set; }
    
    public ICollection<Horarios>  Horarios { get; set; }
    public ICollection<Reservas>   Reservas { get; set; }

    public ICollection<Vehiculos> Vehiculos { get; set; } = new List<Vehiculos>();
    
    public ICollection<RutasDisponibles>  RutasDisponibles { get; set; } = new List<RutasDisponibles>();
}