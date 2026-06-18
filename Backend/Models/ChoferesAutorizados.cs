using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models;

public class ChoferesAutorizados
{
    [Key]
    public int IDChofer { get; set; }

    public string NombreChofer { get; set; } = string.Empty;

    public string TelefonoChofer { get; set; } = string.Empty;

    public int Cupos { get; set; }

    public bool EstadoChofer { get; set; }

    public ICollection<Horarios> Horarios { get; set; }
        = new List<Horarios>();

    public ICollection<Reservas> Reservas { get; set; }
        = new List<Reservas>();
    
    [JsonIgnore]
    public ICollection<Vehiculos> Vehiculos { get; set; }
        = new List<Vehiculos>();

    public ICollection<RutasDisponibles> RutasDisponibles { get; set; }
        = new List<RutasDisponibles>();
}