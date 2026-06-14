using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Horarios
{
    public int IDHorarios { get; set; }
    
    [Column ("Chofer")]
    public int ChoferId { get; set; }
    [ForeignKey(nameof(ChoferId))]
    public ChoferesAutorizados? Chofer { get; set; }
    
    public ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();
}